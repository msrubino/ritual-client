using UnityEngine;

public class Player
{
    private bool _isLeader;
    public bool IsLeader
    {
        get { return _isLeader; }
        set { _isLeader = value; }
    }

    private string _uuid = SystemInfo.deviceUniqueIdentifier;
    public string Uuid
    {
        get { return _uuid; }
        set { _uuid = value; }
    }

    private string _username;
    public string Username
    {
        get { return _username; }
        set { _username = value; }
    }

    public float LastPerformanceSpeed 
    {
        get; set;
    }

    public string DeclaredGestureString
    {
        get; set;
    }
}
