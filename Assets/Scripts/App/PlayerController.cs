using UnityEngine;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public bool shouldSpoofUuid;
    public Player Player { get; set; } 

    public void CreatePlayer() 
    {
        Player = new Player(); 
        Player.Uuid = Guid.NewGuid().ToString();
    }
}
