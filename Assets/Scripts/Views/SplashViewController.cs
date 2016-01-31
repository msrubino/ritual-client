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

            bool hasIdentity = _app.playerController.HasJoinedServerWithName();
            
            if ( hasIdentity ) 
            {
                Debug.Log( "Has identity." );
                HandleExistingUser();
            } else {
                Debug.Log( "Does not have identity." );
                AdvanceToJoin();
            }
        });
    }

    private void HandleExistingUser()
    {
        StartCoroutine( CheckServerForLeader() );
    }

    private IEnumerator CheckServerForLeader()
    {
        yield return StartCoroutine( _api.Join() );

        if ( _rituals.WaitingForCurrentRitualToFinish() )
        {
            Debug.Log( "Waiting for current ritual to finish." );
            AdvanceToPregame();
        } else {
            Debug.Log( "Ready to start round." );
            AdvanceToFollowerStartRound();
        }
    }

    private void AdvanceToPregame()
    {
        TransitionToView(AppController.Instance.viewReferences.pregameView);
    }

    private void AdvanceToFollowerStartRound()
    {
        TransitionToView(AppController.Instance.viewReferences.followerStartRoundView);
    }
    
    private void AdvanceToJoin()
    {
        TransitionToView(AppController.Instance.viewReferences.joinView);
    }

}
