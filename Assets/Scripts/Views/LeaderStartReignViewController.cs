using UnityEngine;
using System.Collections;

public class LeaderStartReignViewController : ViewControllerBase
{
    
    public void Start()
    {
        DelayedAdvanceToChooseRitual();
    }

    private void DelayedAdvanceToChooseRitual()
    {
        TransitionToView(AppController.Instance.appTimes.leaderStartReignAdvance,
                         AppController.Instance.viewReferences.followerDoRitualView);
    }

}
