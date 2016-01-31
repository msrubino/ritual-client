using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeaderChooseRitualViewController : ViewControllerBase 
{

    public Transform buttonParent;

    public void Start()
    {
        Layout();
    }

    public void OnDestroy()
    {
        RemoveAll();
    }

    private void Layout()
    {
        foreach(var mapping in AppController.Instance.ritualTypeMappings.mappings)
        {
            AddButton(mapping);
        }
    }

    private void AddButton(RitualTypeMappings.Mapping mapping)
    {
        var button = Instantiate(mapping.ritualChooseButton, Vector3.zero, Quaternion.identity) as Button;
        var tr = button.transform;
        tr.SetParent(buttonParent, false);
        button.onClick.AddListener(() => {
            ButtonWasClicked(mapping.duration);
        });
    }

    private void ButtonWasClicked(float duration)
    {
        // send ritual
        var waitForRitualView = AppController.Instance.viewReferences.leaderWaitForRitualView as LeaderWaitForRitualViewController;
        waitForRitualView.Duration = duration;
        TransitionToView(waitForRitualView);
    }

    private void RemoveAll()
    {

    }
}
