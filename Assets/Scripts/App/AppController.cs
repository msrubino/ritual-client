using UnityEngine;
using System.Collections;

public class AppController : MonoBehaviour
{

    private static AppController _instance;
    public static AppController Instance
    {
        get { return _instance; }
    }

    public ApiRequestHandler    apiRequestHandler;
    public AudioController      audioController;
    public PlayerController     playerController;
    public RitualsController    ritualsController;
    public ThemeController      themeController;
    public WWWController        wwwController;

    public InfoHud              infoHud;

    public ViewReferences     viewReferences;
    public RitualTypeMappings ritualTypeMappings;
    public AppTimes           appTimes;
    public float              generalPollingDelay;

    public void Awake()
    {
        _instance = this;
    }

    public void Start()
    {
        playerController.CreatePlayer();
    }

}
