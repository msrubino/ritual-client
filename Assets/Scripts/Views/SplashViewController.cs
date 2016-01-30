using UnityEngine;
using System.Collections;

public class SplashViewController : ViewControllerBase 
{

    public float secondsBeforeAdvance;

    public void Start()
    {
        AdvanceToNextView();
    }

    private void AdvanceToNextView()
    {
        Delay(secondsBeforeAdvance, () => {
            // if has identity
            // TransitionToView(AppController.Instance.viewReferencer.introView);
            // else
            TransitionToView(AppController.Instance.viewReferences.joinView);
        });
    }

}
