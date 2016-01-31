using UnityEngine;
using System.Collections;

public class LeaderWaitForRitualViewController : ViewControllerBase
{
    private float _duration;
    public float Duration
    {
        set { _duration = value; }
    }

    public void OnEnable()
    {
        DelayedCheckForResult();
    }

    private void DelayedCheckForResult()
    {
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
        TransitionToView(AppController.Instance.viewReferences.announceRoundWinnerView);
    }
}
