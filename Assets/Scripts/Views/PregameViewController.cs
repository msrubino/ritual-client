using UnityEngine;
using System.Collections;

public class PregameViewController : ViewControllerBase
{

    public float minSecondsBeforeAdvance;

    public void Start()
    {
        Delay(minSecondsBeforeAdvance, () => {
            PollForRoundReady();
        });
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
