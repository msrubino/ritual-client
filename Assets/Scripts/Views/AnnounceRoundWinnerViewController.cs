using UnityEngine;
using System.Collections;

public class AnnounceRoundWinnerViewController : ViewControllerBase
{

    public void Start()
    {
        DelayedAdvanceToNext();
    }

    private void DelayedAdvanceToNext()
    {
        Delay(AppController.Instance.appTimes.roundEndAdvance, () => {
            // if is reign over
            HandleReignOver();
            // else
            // AdvanceToNextRound()
        });
    }

    private void HandleReignOver()
    {
        // if won reign
        // AdvanceToWonReign();
        // else
        // AdvanceToAnnounceReignWinner();
    }


    private void AdvanceToNextRound()
    {
        // if is leader
        // TransitionToView(AppController.Instance.viewReferences.leaderStartRoundView);
        // else
        TransitionToView(AppController.Instance.viewReferences.followerStartRoundView);
    }

    private void AdvanceToAnnounceReignWinner()
    {
        TransitionToView(AppController.Instance.viewReferences.announceReignWinnerView);
    }

    private void AdvanceToWonReign()
    {
        TransitionToView(AppController.Instance.viewReferences.wonReignView);
    }

}
