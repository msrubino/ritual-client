using UnityEngine;
using UnityEngine.UI;

public class WonReignViewController : ViewControllerBase
{
    [SerializeField]
    Text _chosenText;

    public void OnEnable()
    {
        if ( _player.IsLeader ) 
        {
            _chosenText.text = "You have been chosen!";
        } 
        else 
        {
            _chosenText.text = string.Format( "{0} has been chosen!", _players.CurrentLeader.name );
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
