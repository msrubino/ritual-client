using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeaderChooseRitualViewController : ViewControllerBase 
{

    public float startY;
    public float ySpacing;

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
            AddButton(mapping.ritualChooseButton, mapping.ritualType, y);
            y += ySpacing;
        }
    }

    private void AddButton(Button button, RitualType ritualType, float y)
    {
        // add button at y
        // assign action to button: Button
    }

    private void ButtonWasClicked(Ritual ritual)
    {
        // send ritual
        TransitionToView(AppController.Instance.viewReferences.leaderWaitForRitualView);
    }

    private void RemoveAll()
    {

    }
}
