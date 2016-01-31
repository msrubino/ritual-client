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
        if (mapping.ritualChooseButton == null) return;

        var button = Instantiate(mapping.ritualChooseButton, Vector3.zero, Quaternion.identity) as Button;
        var tr = button.transform;
        tr.SetParent(buttonParent, false);
        button.onClick.AddListener(() => {
            StartCoroutine(ButtonWasClicked(mapping));
        });
    }

    private IEnumerator ButtonWasClicked(RitualTypeMappings.Mapping mapping)
    {
        if (_rituals.CurrentRitual == null) {
            _rituals.CurrentRitual = new Ritual();
        }

        _rituals.CurrentRitual.RitualType = mapping.ritualType;
        _rituals.CurrentRitual.Duration = mapping.duration;
        _rituals.CurrentRitual.TimeUntilStart = 10;

        yield return StartCoroutine(_api.DeclareRitual());

        _app.themeController.ActivateElement(mapping.elementTheme);

        var waitForRitualView = AppController.Instance.viewReferences.leaderWaitForRitualView as LeaderWaitForRitualViewController;
        waitForRitualView.Duration = mapping.duration + _rituals.CurrentRitual.TimeUntilStart;
        waitForRitualView.CurrentTheme = mapping.elementTheme;
        TransitionToView(waitForRitualView);
    }

    private void RemoveAll()
    {

    }
}
