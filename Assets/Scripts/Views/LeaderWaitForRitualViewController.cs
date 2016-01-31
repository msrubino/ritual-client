using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class LeaderWaitForRitualViewController : ViewControllerBase
{
    [SerializeField]
    Text _ritualBegin, _informFollowers;

    private float _duration;
    public float Duration
    {
        set { _duration = value; }
    }

    public string LeaderInstructions { get; set; }
    public ElementTheme CurrentTheme { get; set; }

    public void OnEnable()
    {
        _informFollowers.text = LeaderInstructions;
        DelayedCheckForResult();
    }

    private void DelayedCheckForResult()
    {
        Delay(Time.time - _rituals.CurrentRitual.TrackedTimeUntilStart, () => {
            _ritualBegin.text = "The ritual has begun!"; 
        });

        Delay(_duration, () => {
            StartCoroutine(CheckForResult());
        });
    }

    private IEnumerator CheckForResult()
    {
         yield return StartCoroutine(_api.RitualResults());
         AdvanceToAnnounceRoundWinner();
    }

    private void AdvanceToAnnounceRoundWinner()
    {
        _app.themeController.DeactivateElement(CurrentTheme);
        TransitionToView(AppController.Instance.viewReferences.announceRoundWinnerView);
    }
}
