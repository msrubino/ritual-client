﻿using UnityEngine;
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

        RitualObj currentRitual = JsonUtility.FromJson<RitualObj>( request.text );

        RitualPlayer leader = JsonUtility.FromJson<RitualPlayer>( request.text );
        Debug.Log( leader );
        //TODO what do with with current ritual information next?
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

        string leaderJSON = JsonHelper.GetJsonObject( request.text, "leader" );
        RitualPlayer leader = JsonUtility.FromJson<RitualPlayer>( leaderJSON );
        _players.SetCurrentLeader( leader );

        string ritualJSON = JsonHelper.GetJsonObject( request.text, "ritual" );
        if ( ritualJSON != null )
        {
            _rituals.SetCurrentRitual( null );
        } else {
            RitualObj ritual = JsonUtility.FromJson<RitualObj>( request.text );
            _rituals.SetCurrentRitual( ritual );
        }

        //TODO Nec'y?
        _player.IsLeader = leader.uuid == _player.Uuid ;

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

        if ( HasRequestError( request.error ) ) yield break;
        
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
        return CreateRequest( url, _fields );
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

        return CreateRequest( url, _fields );
    }

    private WWW CreateRitualResultsRequest()
    {
        string url = _www.ritualResultsURL;
        _fields.Clear();
        return CreateRequest( url, _fields );
    }

    // Helper Functions --------------------------------------------------
    private WWW CreateRequest( string url, Dictionary<string, object> fields )
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

        return error != null;
    }

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
}


