using UnityEngine;
using System.Collections;

public class AnnounceRoundWinnerViewController : ViewControllerBase
{
    public void OnEnable()
    {
        DelayedAdvanceToNext();
    }

    private void DelayedAdvanceToNext()
    {
        Delay(AppController.Instance.appTimes.roundEndAdvance, () => {
            bool leaderChanged = LeaderChanged();
            _players.UpdateLeaderAtEndOfRound();

            if (leaderChanged) 
            {
                HandleReignOver(); 
            } 
            else 
            {
                AdvanceToNextRound();
            }
        });
    }

    private bool LeaderChanged() 
    {
        return _players.LeaderAtEndOfLastRitual.uuid != _players.CurrentLeader.uuid;
    }

    private void HandleReignOver()
    {
        if (_player.IsLeader) 
        {
            AdvanceToWonReign();
        } 
        else 
        {
            AdvanceToAnnounceReignWinner();
        }
    }

    private void AdvanceToNextRound()
    {
        if (_player.IsLeader)
        {
            TransitionToView(AppController.Instance.viewReferences.leaderStartRoundView);
        }
        else 
        {
            TransitionToView(AppController.Instance.viewReferences.followerStartRoundView);
        }
    }

    private void AdvanceToAnnounceReignWinner()
    {
        TransitionToView(AppController.Instance.viewReferences.announceReignWinnerView);
    }

    private void AdvanceToWonReign()
    {
        TransitionToView(AppController.Instance.viewReferences.wonReignView);
    }
}
