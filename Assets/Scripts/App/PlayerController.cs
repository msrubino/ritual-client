using UnityEngine;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public string playerPrefsNameKey = "JOINED_WITH_NAME";

    public bool shouldSpoofUuid;
    public Player Player { get; set; } 
    public RitualPlayer Leader { get; set; }

    public RitualPlayer LastRitualWinner { get; private set; }
    public RitualPlayer LeaderAtEndOfLastRitual { get; private set; }

    public void CreatePlayer() 
    {
        Player = new Player(); 
        if ( shouldSpoofUuid ) Player.Uuid = Guid.NewGuid().ToString();
    }

    public bool HasJoinedServerWithName()
    {
        string name = PlayerPrefs.GetString( playerPrefsNameKey );

        if ( name != "" )
        {
            Player.Username = name;
            return true;
        }

        return false;
    }

    public void SetCurrentLeader( RitualPlayer leader )
    {
        Leader = leader;
        Debug.Log( "Setting the leader -- " + leader.name );
    }

    public void SetLeaderAtEndOfLastRitual( RitualPlayer leader )
    {
        LeaderAtEndOfLastRitual = leader;
        Debug.Log( "Setting the leader -- " + leader.name );
    }

    public void SetLastRitualWinner( RitualPlayer winner )
    {
        LastRitualWinner = winner;
        Debug.Log( "Setting the last winner -- " + winner.name );
    }

    public void UpdateLeaderAtEndOfRound() 
    {
        Leader = LeaderAtEndOfLastRitual;
        ClearLastRitualPlayerInformation();
    }

    private void ClearLastRitualPlayerInformation() 
    {
        LastRitualWinner = null;
        LeaderAtEndOfLastRitual = null;
    }
}
