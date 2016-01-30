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
        bool hasIdentity = PlayerPrefs.GetString( _app.playerController.playerPrefsNameKey ) != "";

        Delay(AppController.Instance.appTimes.minSplashAdvance, () => {
            if ( hasIdentity ) AdvanceToPregame();
            else AdvanceToJoin();
        });
    }

    private void AdvanceToPregame()
    {
        TransitionToView(AppController.Instance.viewReferences.pregameView);
    }

    private void AdvanceToJoin()
    {
        TransitionToView(AppController.Instance.viewReferences.joinView);
    }

}
