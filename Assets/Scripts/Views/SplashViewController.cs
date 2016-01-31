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
        bool hasIdentity = _app.playerController.HasJoinedServerWithName();

        Delay(AppController.Instance.appTimes.minSplashAdvance, () => {
            if ( hasIdentity ) HandleExistingUser();
            else AdvanceToJoin();
        });
    }

    private void HandleExistingUser()
    {
        // send uuid to server
        // if round ready
        AdvanceToStartRound();
        // else
        // AdvanceToPregame();
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
