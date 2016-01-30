using UnityEngine;
using System.Collections;

public class LeaderWaitForRitualViewController : ViewControllerBase
{

    public float timeToSync;

    public void Start()
    {
        DelayedSync();
    }

    private void DelayedSync()
    {
        float delay = Mathf.Min(0f, timeToSync - Time.time);
        Delay(delay, () => {
            Sync();
        });
    }

    private void Sync()
    {
        // sync
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
