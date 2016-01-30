using UnityEngine;
using System.Collections;

public class AppController : MonoBehaviour
{

    private static AppController _instance;
    public static AppController Instance
    {
        get { return _instance; }
    }

    public void Awake()
    {
        _instance = this;
    }

}
