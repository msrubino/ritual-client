using UnityEngine;
using UnityEngine.UI;

public class AnnounceReignWinnerViewController : ViewControllerBase
{
    [SerializeField]
    Text _reignWinner;

    public void OnEnable()
    {
        if ( _player.IsLeader )
        {
            _reignWinner.text = "You have been Chosen!";
        }
        else 
        {
            _reignWinner.text = string.Format( "{0} has been Chosen!", _players.CurrentLeader.name );
        }

        DelayedAdvanceToNextReign();
    }

    private void DelayedAdvanceToNextReign()
    {
        if ( _player.IsLeader )
        {
            TransitionToView(AppController.Instance.appTimes.reignEndAdvance,
                AppController.Instance.viewReferences.leaderStartRoundView);
        }
        else
        {
            TransitionToView(AppController.Instance.appTimes.reignEndAdvance,
                             AppController.Instance.viewReferences.followerStartRoundView);
        }
    }

}
