using UnityEngine;
using System.Collections;

public class LeaderWaitForRitualViewController : ViewControllerBase
{

    private float _duration;
    public float Duration
    {
        set { _duration = value; }
    }

    public void Start()
    {
        DelayedCheckForResult();
    }

    private void DelayedCheckForResult()
    {
        Delay(_duration, () => {
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
}
