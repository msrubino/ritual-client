using UnityEngine;
using System.Collections;

public class SplashViewController : ViewControllerBase 
{

    public void Start()
    {
        AdvanceToNextView();
    }

    private void AdvanceToNextView()
    {
        Delay(AppController.Instance.appTimes.minSplashAdvance, () => {
            // if has identity
                // if round ready
                // AdvanceToStartRound();
                // else
                // AdvanceToPregame();
            // else
            AdvanceToJoin();
        });
    }

    private void AdvanceToPregame()
    {
        TransitionToView(AppController.Instance.viewReferences.pregameView);
    }

    private void AdvanceToStartRound()
    {
        TransitionToView(AppController.Instance.viewReferences.followerStartRoundView);
    }
    
    private void AdvanceToJoin()
    {
        TransitionToView(AppController.Instance.viewReferences.joinView);
    }

}
