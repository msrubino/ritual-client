using UnityEngine;
using System.Collections;

public class ApiRequestHandler : MonoBehaviourBase
{
    public IEnumerator Join()
    {
        WWW request = CreateJoinPOSTRequest();

        yield return request;

        string leaderJSON = JsonHelper.GetJsonObject( request.text, "leader" );
        RitualPlayer leader = JsonUtility.FromJson<RitualPlayer>( leaderJSON );

        _player.IsLeader = leader.uuid == _player.Uuid ;
        if ( _player.IsLeader ) Debug.Log( "I am the leader." );
    }

    private WWW CreateJoinPOSTRequest()
    {

        WWWForm form = new WWWForm(); 
        form.AddField( "uuid", _player.Uuid );
        form.AddField( "name", _player.Username );
        
        string url = _www.joinURL;
        return new WWW( url, form );

    }
}
