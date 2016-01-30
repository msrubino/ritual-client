using UnityEngine;
using System.Collections;

public class PregameViewController : ViewControllerBase
{

    public void Start()
    {
        PollForRoundReady();
    }

    private void PollForRoundReady()
    {
        // poll
        // handle poll response
    }

    private void HandlePollResponse()
    {
        // if ready
        // AdvanceToStartRound();
        //else
        // Delay(AppController.Instance.appTimes.roundReadyPoll, () => {
        //     PollForRoundReady();
        // });
    }
        
    private void AdvanceToStartRound()
    {
        TransitionToView(AppController.Instance.viewReferences.followerStartRoundView);
    }
    
}
