using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class LeaderWaitForRitualViewController : ViewControllerBase
{
    [SerializeField]
    Text _ritualBegin, _informFollowers;

    string _originalText;

    private float _duration;
    public float Duration
    {
        set { _duration = value; }
    }

    public string LeaderInstructions { get; set; }
    public ElementTheme CurrentTheme { get; set; }

    void Awake() 
    {
        _originalText = _ritualBegin.text;
    }

    public void OnEnable()
    {
        _informFollowers.text = LeaderInstructions;
        DelayedCheckForResult();
    }

    void OnDisable()
    {
        _ritualBegin.text = _originalText;
    }

    private void DelayedCheckForResult()
    {
        Delay((_rituals.CurrentRitual.TrackedTimeUntilStart + _rituals.CurrentRitual.TimeUntilStart) - Time.time, () => {
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
