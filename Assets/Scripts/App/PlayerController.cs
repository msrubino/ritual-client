using UnityEngine;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public string playerPrefsNameKey = "JOINED_WITH_NAME";

    public bool shouldSpoofUuid;
    public Player Player { get; set; } 

    public void CreatePlayer() 
    {
        Player = new Player(); 
        Player.Uuid = Guid.NewGuid().ToString();
    }

    public bool HasJoinedServerWithName()
    {
        return PlayerPrefs.GetString( playerPrefsNameKey ) != "";
    }
}
