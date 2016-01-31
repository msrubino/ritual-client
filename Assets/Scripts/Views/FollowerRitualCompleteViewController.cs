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
        // AdvanceToRoundWinner()
    }

    private void AdvanceToRoundWinner()
    {
        // AdvanceToAnnounceRoundWinner();
    }

    private void AdvanceToAnnounceRoundWinner()
    {
        TransitionToView(AppController.Instance.viewReferences.announceRoundWinnerView);
    }

}
