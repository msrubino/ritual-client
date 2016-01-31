using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApiRequestHandler : MonoBehaviourBase
{
    private Dictionary<string, object> _fields = new Dictionary<string, object>();

    // Ritual Coroutines --------------------------------------------------
    public IEnumerator CurrentRitual()
    {
        WWW request = CreateCurrentRitualRequest();
        yield return request;

        if ( HasRequestError( request.error ) ) yield break;

        Debug.Log( request.text );

        CurrentRitualResponse resp = JsonUtility.FromJson<CurrentRitualResponse>( request.text );
        if ( resp == null)
        {
            yield break;
        }

        if ( resp.leader != null ) 
        {
            RitualPlayer leader = resp.leader;
            _players.SetCurrentPollLeader( leader );
        }

        if ( resp.ritual != null && resp.ritual.duration != 0 ) 
        {
            RitualObj currentRitual = resp.ritual;
            _rituals.SetCurrentPollRitual( Ritual.FromRitualObj( currentRitual ) );
        }
    }

    public IEnumerator DeclareRitual()
    {
        WWW request = CreateDeclareRitualRequest();
        yield return request;

        if ( HasRequestError( request.error ) ) yield break;
    }

    public IEnumerator Join()
    {
        WWW request = CreateJoinRequest(); 
        yield return request;

        if ( HasRequestError( request.error ) ) yield break;

        CurrentRitualResponse resp = JsonUtility.FromJson<CurrentRitualResponse>( request.text );
        if ( resp == null )
        {
            yield break;
        }

        RitualPlayer leader = resp.leader;
        _players.SetCurrentLeader( leader );

        RitualObj ritual = resp.ritual;
        if ( ritual.duration != 0 )
        {
            _rituals.SetCurrentPollRitual( Ritual.FromRitualObj( ritual ) );
        }
        else 
        {
            _rituals.SetCurrentRitual( null );
            _rituals.SetCurrentPollRitual( null );
        }

        PlayerPrefs.SetString( _app.playerController.playerPrefsNameKey, _player.Username );
    }

    public IEnumerator PerformedRitual()
    {
        WWW request = CreatePerformedRitualRequest();
        yield return request;

        if ( HasRequestError( request.error ) ) yield break;
    }

    public IEnumerator RitualResults()
    {
        WWW request = CreateRitualResultsRequest();
        yield return request;

        //if ( HasRequestError( request.error ) ) yield break;
        
        string winnerJSON = JsonHelper.GetJsonObject( request.text, "winner" );
        RitualPlayer winner = JsonUtility.FromJson<RitualPlayer>( winnerJSON );

        string leaderJSON = JsonHelper.GetJsonObject( request.text, "leader" );
        RitualPlayer leader = JsonUtility.FromJson<RitualPlayer>( leaderJSON );

        _players.SetLastRitualWinner(winner);
        _players.SetLeaderAtEndOfLastRitual(leader);
    }

    // Request Functions --------------------------------------------------
    private WWW CreateCurrentRitualRequest()
    {
        string url = _www.currentRitualURL;
        _fields.Clear();
        return CreateRequest( url );
    }

    private WWW CreateDeclareRitualRequest()
    {
        string url = _www.declareRitualURL;

        _fields.Clear();
        _fields.Add( "uuid", _player.Uuid );
        _fields.Add( "ritual_type", (int)_rituals.CurrentRitual.RitualType );
        _fields.Add( "duration", _rituals.CurrentRitual.Duration );
        _fields.Add( "starts_in", _rituals.CurrentRitual.TimeUntilStart );

        return CreateRequest( url, _fields );
    }

    private WWW CreateJoinRequest()
    {
        string url = _www.joinURL;

        _fields.Clear();
        _fields.Add( "uuid", _player.Uuid );
        _fields.Add( "name", _player.Username );

        return CreateRequest( url, _fields );
    }

    private WWW CreatePerformedRitualRequest()
    {
        string url = _www.performedRitualURL;

        _fields.Clear();
        _fields.Add( "uuid", _player.Uuid );

        if ( _player.LastPerformanceSpeed != 0 ) 
        {
        _fields.Add( "performance_speed", _player.LastPerformanceSpeed );
        }

        if ( _player.LastGestureString != null )
        {
            _fields.Add( "gesture_string", _player.LastGestureString );
        }

        WWW req = CreateRequest( url, _fields );
        _player.LastPerformanceSpeed = 0;
        _player.LastGestureString = null;
        return req;
    }

    private WWW CreateRitualResultsRequest()
    {
        string url = _www.ritualResultsURL;
        _fields.Clear();
        return CreateRequest( url );
    }

    // Helper Functions --------------------------------------------------
    private WWW CreateRequest( string url )
    {
        WWWForm form = new WWWForm();
        return new WWW( url );
    }

    private WWW CreateRequest( string url, Dictionary<string, object> fields )
    {
        _infoHud.Log( "Pinging API - " + url );
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

        return error != null;
    }

    // Context Menu Functions --------------------------------------------------
    [ContextMenu ("Reset Server")]
    private void ResetServer()
    {
        StartCoroutine( Reset() );
    }

    private IEnumerator Reset()
    {
        PlayerPrefs.DeleteAll();

        string url = _www.resetURL;
        WWW request = new WWW( url );
        
        yield return request;

        if ( HasRequestError( request.error ) ) yield break;
    }

    [ContextMenu ("DeclareRitual" )]
    private void IDoDeclareRitual()
    {
        string url = _www.declareRitualURL;

        _fields.Clear();
        _fields.Add( "uuid", _players.CurrentLeader.uuid );
        _fields.Add( "ritual_type", 0 );
        _fields.Add( "duration", 10f );
        _fields.Add( "starts_in", 5f );
        
        CreateRequest( url, _fields );
    }
}


