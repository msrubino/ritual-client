using UnityEngine;
using System.Collections;

public class AppController : MonoBehaviour
{

    private static AppController _instance;
    public static AppController Instance
    {
        get { return _instance; }
    }

    public ViewReferences viewReferences;
    public RitualTypeMappings ritualTypeMappings;
    public AppTimes appTimes;
    public void Awake()
    {
        _instance = this;
    }

}
