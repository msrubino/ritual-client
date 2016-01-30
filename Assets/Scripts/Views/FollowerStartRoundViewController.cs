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
        // HandlePollResponse();
    }

    private void HandlePollResponse()
    {
        // if round started
        HandleRoundStarted();
        // else
        // Delay(AppController.Instance.appTimes.startRoundPoll, () => {
            // PollForRoundStarted();
        // }); 
    }

    private void HandleRoundStarted()
    {
        // parse ritual info from response
        AdvanceToDoRitual();
    }

    private void AdvanceToDoRitual()
    {
        TransitionToView(AppController.Instance.viewReferences.followerDoRitualView);
    }

}
