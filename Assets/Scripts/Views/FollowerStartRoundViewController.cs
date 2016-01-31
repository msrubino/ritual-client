using UnityEngine;
using System.Collections;

public class FollowerStartRoundViewController : ViewControllerBase
{
    private Ritual _ritual;

    public void Start()
    {
        StartCoroutine( PollForRitualStarted() );
    }

    private IEnumerator PollForRitualStarted()
    {
        while( true )
        {
            Debug.Log( "Starting to poll for ritual started." );
            yield return StartCoroutine( _api.CurrentRitual() );
            if ( _rituals.HasCurrentActiveRitual() ) yield break;
            yield return new WaitForSeconds( 1f );
        }

        Debug.Log( "Current active ritual is ready." );
        HandlePollResponse();
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
        TransitionToView(AppController.Instance.viewReferences.wonReignView);
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
