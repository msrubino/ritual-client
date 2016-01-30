using UnityEngine;
using System.Collections;

public class PregameViewController : ViewControllerBase
{

    public void Start()
    {
        PollForRoundReady();
    }

    private void PollForRoundReady()
    {
        // poll
        // if ready
        AdvanceToStartRound();
        //else
        // PollForRoundReady()
    }

    private void AdvanceToStartRound()
    {
        TransitionToView(AppController.Instance.viewReferences.followerStartRoundView);
    }
    
}
