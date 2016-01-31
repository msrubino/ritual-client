using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RitualCountdownViewController : ViewControllerBase 
{

    public Text countdownText;

    private Ritual _ritual;
    public Ritual Ritual
    {
        set { _ritual = value; }
    }

    public void Start()
    {
        StartCoroutine(DoCountdown());
    }

    private IEnumerator DoCountdown()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);
        AdvanceToDoRitual();
    }

    private void AdvanceToDoRitual()
    {
        var doRitualView = AppController.Instance.viewReferences.followerDoRitualView as FollowerDoRitualViewController;
        doRitualView.Ritual = _ritual;
        TransitionToView(doRitualView);
    }

}
