using UnityEngine;

public class Player
{

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

}
