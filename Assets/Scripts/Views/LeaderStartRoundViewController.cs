using UnityEngine;
using System.Collections;

public class LeaderStartRoundViewController : ViewControllerBase
{
    
    public void Start()
    {
        DelayedAdvanceToChooseRitual();
    }

    private void DelayedAdvanceToChooseRitual()
    {
        TransitionToView(AppController.Instance.appTimes.leaderStartRoundAdvance,
                         AppController.Instance.viewReferences.followerDoRitualView);
    }

}
