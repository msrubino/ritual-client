using UnityEngine;
using System.Collections;

public class FollowerDoRitualViewController : ViewControllerBase 
{

    public RitualType ritualType;

    private Ritual _ritual;

    public void Start()
    {
        CreateRitualObject();
        BeginRitual();
    }

    private void CreateRitualObject()
    {
        var ritual = AppController.Instance.ritualTypeMappings.GetRitualForType(ritualType);
        _ritual = Instantiate(ritual, Vector3.zero, Quaternion.identity) as Ritual;
    }

    private void BeginRitual()
    {
        _ritual.Begin();
        _ritual.DidComplete += RitualDidComplete;
    }

    private void RitualDidComplete()
    {
        Destroy(_ritual.gameObject);
        TransitionToView(AppController.Instance.viewReferences.followerRitualCompleteView);
    }

}
