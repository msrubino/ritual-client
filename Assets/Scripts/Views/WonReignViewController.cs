using UnityEngine;
using System.Collections;

public class WonReignViewController : ViewControllerBase
{

    public void Start()
    {
        DelayedAdvanceToNextReign();
    }

    private void DelayedAdvanceToNextReign()
    {
        // if is leader
        // TransitionToView(AppController.Instance.appTimes.reignEndAdvance,
                            // AppController.Instance.viewReferences.leaderStartRoundView);
        // else
        TransitionToView(AppController.Instance.appTimes.reignEndAdvance,
                         AppController.Instance.viewReferences.followerStartRoundView);
    }

}
