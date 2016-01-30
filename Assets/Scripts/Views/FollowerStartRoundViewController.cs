using UnityEngine;
using System.Collections;

public class FollowerStartRoundViewController : ViewControllerBase
{

    private Ritual _ritual;

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
        // if new leader
        // AdvanceToLeaderFailed();
        // if round started
        HandleRoundStarted();
        // else
        // Delay(AppController.Instance.appTimes.startRoundPoll, () => {
            // PollForRoundStarted();
        // }); 
    }

    private void AdvanceToLeaderFailed()
    {
        TransitionToView(AppController.Instance.viewReferences.leaderFailedView);
    }

    private void HandleRoundStarted()
    {
        // parse ritual info from response
        AdvanceToCountdown();
    }

    private void AdvanceToCountdown()
    {
        var countdownView = AppController.Instance.viewReferences.ritualCountdownView as RitualCountdownViewController;
        countdownView.Ritual = _ritual;
        TransitionToView(countdownView);
    }

}
