using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FollowerStartRoundViewController : ViewControllerBase
{
    public Text newLeaderNameText;
    public void OnEnable()
    {
        StartCoroutine( PollForRitualStarted() );
    }

    private IEnumerator PollForRitualStarted()
    {
        while( true )
        {
            yield return StartCoroutine( _api.CurrentRitual() );

            if ( LeaderFailed() ) 
            {
                AdvanceToLeaderFailed();
                yield break;
            }

            HandlePollResponse();

            if ( _rituals.HasCurrentActiveRitual() ) 
            {
                Delay(_rituals.CurrentRitual.TimeUntilStart - 3 /* it's late */, () => {
                    AdvanceToCountdown();
                }); 
                yield break;
            }
            yield return new WaitForSeconds( 1f );
        }
    }

    private bool LeaderFailed() {
        bool leadersExist = _players.CurrentLeader != null && _players.CurrentPollLeader != null;
        if ( leadersExist && _players.CurrentLeader.uuid != _players.CurrentPollLeader.uuid )
        {
            return true;
        }

        return false;
    }

    private void HandlePollResponse()
    {
        if ( _rituals.CurrentPollRitual != null ) 
        {
            _rituals.CurrentRitual = _rituals.CurrentPollRitual;
            _rituals.CurrentPollRitual = null;
        }
    }

    private void AdvanceToLeaderFailed()
    {
        _players.SetCurrentLeader( _players.CurrentPollLeader );
        newLeaderNameText.text = _players.CurrentPollLeader.name;

        if ( _player.Uuid == _players.CurrentPollLeader.uuid )
        {
            TransitionToView(AppController.Instance.viewReferences.wonReignView);
        }
        else
        {
            TransitionToView(AppController.Instance.viewReferences.announceReignWinnerView);
        }

    }

    private void AdvanceToCountdown()
    {
        var countdownView = AppController.Instance.viewReferences.ritualCountdownView as RitualCountdownViewController;
        TransitionToView(countdownView);
    }
}
