using UnityEngine;
using System.Collections;

public class LeaderWaitForRitualViewController : ViewControllerBase
{

    private Ritual _ritual;
    public Ritual Ritual
    {
        set { _ritual = value; }
    }

    public void Start()
    {
        DelayedCheckForResult();
    }

    private void DelayedCheckForResult()
    {
        Delay(_ritual.Duration, () => {
            CheckForResult();
        });
    }

    private void CheckForResult()
    {
        // check for result
        // ParseResponse();
    }

    private void ParseResponse()
    {
        // if reign won
        // AdvanceToReignWon();
        // else
        // AdvanceToRoundWon();
    }

    private void AdvanceToReignWon()
    {
        TransitionToView(AppController.Instance.viewReferences.wonReignView);
    }
    
    private void AdvanceToRoundWon()
    {
        TransitionToView(AppController.Instance.viewReferences.wonRoundView);
    }

}
