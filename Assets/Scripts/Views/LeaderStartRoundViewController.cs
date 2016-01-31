using UnityEngine;
using UnityEngine.UI;

public class LeaderStartRoundViewController : ViewControllerBase
{
    [SerializeField]
    Text _youAreChosenText;

    public void Start()
    {
        _youAreChosenText.text = string.Format("{0}!", _players.playerPrefsNameKey);
        DelayedAdvanceToChooseRitual();
    }

    private void DelayedAdvanceToChooseRitual()
    {
        TransitionToView(_app.appTimes.leaderStartRoundAdvance,
                         _app.viewReferences.leaderChooseRitualView);
    }

}
