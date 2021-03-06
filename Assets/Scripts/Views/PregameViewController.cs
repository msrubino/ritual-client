﻿using UnityEngine;
using System.Collections;

public class PregameViewController : ViewControllerBase
{

    public void OnEnable()
    {
        PollForRoundReady();
    }

    private void PollForRoundReady()
    {
        // poll
        // handle poll response
        AdvanceToStartRound();
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
