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
            // TransitionToView(AppController.Instance.viewReferencer.pregameView);
            // else
            TransitionToView(AppController.Instance.viewReferences.joinView);
        });
    }

}
