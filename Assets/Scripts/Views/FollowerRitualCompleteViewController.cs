using UnityEngine;
using System.Collections;

public class FollowerRitualCompleteViewController : ViewControllerBase
{

    private float _timeToCheckForResult;
    public float TimeToCheckForResult
    {
        set { _timeToCheckForResult = value; }
    }

    public void Start()
    {
        StartCoroutine(WaitToCheckForResult());
    }

    private IEnumerator WaitToCheckForResult()
    {
        while (Time.time < _timeToCheckForResult)
        {
            yield return null;
        }
        CheckForResult();
    }

    private void CheckForResult()
    {
        // check for result
        // HandleResultResponse();
    }

    private void HandleResultResponse()
    {
        // if reign over
        // HandleReignOver();
        // else
        // HandleRoundOver()
    }

    private void HandleReignOver()
    {
        // if won reign
        // AdvanceToWonReign();
        // else
        // AdvanceToAnnounceReignWinner();
    }

    private void HandleRoundOver()
    {
        // if won round
        // AdvanceToWonRound();
        // else 
        // AdvanceToAnnounceRoundWinner();
    }

    private void AdvanceToWonReign()
    {
        TransitionToView(AppController.Instance.viewReferences.wonReignView);
    }

    private void AdvanceToAnnounceReignWinner()
    {
        TransitionToView(AppController.Instance.viewReferences.announceReignWinnerView);
    }

    private void AdvanceToWonRound()
    {
        TransitionToView(AppController.Instance.viewReferences.wonRoundView);
    }

    private void AdvanceToAnnounceRoundWinner()
    {
        TransitionToView(AppController.Instance.viewReferences.announceRoundWinnerView);
    }

}
