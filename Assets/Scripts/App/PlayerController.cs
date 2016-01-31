using UnityEngine;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public string playerPrefsNameKey = "JOINED_WITH_NAME";

    public bool shouldSpoofUuid;
    public Player Player { get; set; } 
    public RitualPlayer Leader { get; set; }

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
}
