using UnityEngine;
using System.Collections;

public class AnnounceRoundWinnerViewController : ViewControllerBase
{

    public void Start()
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
