using UnityEngine;
using System.Collections;

public class LeaderFailedViewController : ViewControllerBase
{

    public void OnEnable()
    {
        DelayedAdvanceToNextRound();
    }

    private void DelayedAdvanceToNextRound()
    {
        // if is leader
        // TransitionToView(AppController.Instance.appTimes.roundEndAdvance,
                            // AppController.Instance.viewReferences.leaderStartRoundView);
        // else
        TransitionToView(AppController.Instance.appTimes.roundEndAdvance,
                         AppController.Instance.viewReferences.followerStartRoundView);
    }

}