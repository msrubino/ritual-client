using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeaderChooseRitualViewController : ViewControllerBase 
{

    public float startY;
    public float ySpacing;
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
        float y = startY;
        foreach(var mapping in AppController.Instance.ritualTypeMappings.mappings)
        {
            AddButton(mapping, y);
            y += ySpacing;
        }
    }

    private void AddButton(RitualTypeMappings.Mapping mapping, float y)
    {
        var button = Instantiate(mapping.ritualChooseButton, Vector3.zero, Quaternion.identity) as Button;
        var tr = button.transform;
        tr.parent = buttonParent;
        tr.localPosition = new Vector3(0f, y, 0f);
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
