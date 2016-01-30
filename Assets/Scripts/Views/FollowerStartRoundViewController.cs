using UnityEngine;
using System.Collections;

public class FollowerStartRoundViewController : ViewControllerBase
{

    public void Start()
    {
        PollForRoundStarted();
    }

    private void PollForRoundStarted()
    {
        // poll
        // if started
        AdvanceToDoRitual();
        // else
        // PollForRoundStarted();
    }

    private void AdvanceToDoRitual()
    {
        TransitionToView(AppController.Instance.viewReferences.followerDoRitualView);
    }

}
