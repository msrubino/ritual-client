using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApiRequestHandler : MonoBehaviourBase
{
    private Dictionary<string, object> _fields = new Dictionary<string, object>();

    public IEnumerator Join()
    {
        WWW request = CreateJoinRequest(); 
        yield return request;
        
        if ( HasRequestError( request.error ) ) yield break;

        string leaderJSON = JsonHelper.GetJsonObject( request.text, "leader" );
        RitualPlayer leader = JsonUtility.FromJson<RitualPlayer>( leaderJSON );

        _player.IsLeader = leader.uuid == _player.Uuid ;
        if ( _player.IsLeader ) Debug.Log( "I am the leader." );

        PlayerPrefs.SetString( _app.playerController.playerPrefsNameKey, _player.Username );
    }

    public IEnumerator PerformedRitual()
    {
        WWW request = CreatePerformedRitualRequest();
        yield return request;

        if ( HasRequestError( request.error ) ) yield break;
    }

    private WWW CreateJoinRequest()
    {
        string url = _www.joinURL;

        _fields.Clear();
        _fields.Add( "uuid", _player.Uuid );
        _fields.Add( "name", _player.Username );

        return CreatePOSTRequest( url, _fields );
    }

    private WWW CreatePerformedRitualRequest()
    {
        string url = _www.performedRitualURL;

        _fields.Clear();
        _fields.Add( "uuid", _player.Uuid );

        return CreatePOSTRequest( url, _fields );
    }

    private WWW CreatePOSTRequest( string url, Dictionary<string, object> fields )
    {
        WWWForm form = new WWWForm();
        foreach( KeyValuePair<string, object> kvp in fields )
        {
            form.AddField( kvp.Key, kvp.Value.ToString() );
        }

        return new WWW( url, form );
    }

    private bool HasRequestError( string error )
    {
        if ( error != null )
        {
            Debug.Log( "REQUEST ERROR!: " + error );
        }

        return error == null;
    }
}


