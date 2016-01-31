using UnityEngine;
using System;
using System.Collections;

public class PlayerController : MonoBehaviourBase 
{
    public string playerPrefsNameKey = "JOINED_WITH_NAME";

    //Debug
    public bool shouldSpoofUuid;
    public bool shouldAlwaysRemakeName;

    public Player Player { get; set; } 
    public RitualPlayer LastRitualWinner { get; private set; }

    public RitualPlayer CurrentLeader { get; set; }
    public RitualPlayer CurrentPollLeader { get; set; }
    public RitualPlayer LeaderAtEndOfLastRitual { get; private set; }

    public void CreatePlayer() 
    {
        Player = new Player(); 
        if ( shouldSpoofUuid ) Player.Uuid = Guid.NewGuid().ToString();
    }

    public bool HasJoinedServerWithName()
    {
        string name = PlayerPrefs.GetString( playerPrefsNameKey );

        if ( name != "" && !shouldAlwaysRemakeName )
        {
            Player.Username = name;
            return true;
        }

        return false;
    }

    public void SetCurrentLeader( RitualPlayer leader )
    {
        CurrentLeader = leader;
        _player.IsLeader = leader.uuid == _player.Uuid;

        Debug.Log( "Setting the leader -- " + leader.name );
    }

    public void SetLeaderAtEndOfLastRitual( RitualPlayer leader )
    {
        LeaderAtEndOfLastRitual = leader;
        Debug.Log( "Setting the end-of-ritual leader -- " + leader.name );
    }

    public void SetCurrentPollLeader( RitualPlayer pollLeader )
    {
        CurrentPollLeader = pollLeader;
        Debug.Log( "Setting the current poll leader -- " + pollLeader.name );

        if ( CurrentLeader == null )
        {
            SetCurrentLeader( CurrentPollLeader );
        }
    }

    public void SetLastRitualWinner( RitualPlayer winner )
    {
        if (winner == null) 
        {
            winner = new RitualPlayer();
            winner.name = "Nobody";
            winner.uuid = "_";
        }

        LastRitualWinner = winner;
        Debug.Log( "Setting the last winner -- " + winner.name );
    }

    public void UpdateLeaderAtEndOfRound() 
    {
        SetCurrentLeader( LeaderAtEndOfLastRitual );
        ClearLastRitualPlayerInformation();
    }

    private void ClearLastRitualPlayerInformation() 
    {
        LastRitualWinner = null;
        LeaderAtEndOfLastRitual = null;
    }
}
