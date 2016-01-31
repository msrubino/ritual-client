using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnnounceRoundWinnerViewController : ViewControllerBase
{
    public Text winnerNameText;

    public void OnEnable()
    {
        DelayedAdvanceToNext();
    }

    private void DelayedAdvanceToNext()
    {
        if ( _players.LastRitualWinner.name == "We need to try harder." ) 
        {
            winnerNameText.text = _players.LastRitualWinner.name;
        }
        else
        {
            winnerNameText.text = string.Format("{0} is the most devout.", _players.LastRitualWinner.name);
        }

        Delay(_app.appTimes.roundEndAdvance, () => {
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
        if ( _player.IsLeader )
        {
            TransitionToView( _app.viewReferences.leaderStartRoundView );
        }
        else 
        {
            TransitionToView( _app.viewReferences.followerStartRoundView );
        }
    }

    private void AdvanceToAnnounceReignWinner()
    {
        TransitionToView( _app.viewReferences.announceReignWinnerView );
    }

    private void AdvanceToWonReign()
    {
        TransitionToView( _app.viewReferences.wonReignView );
    }
}
