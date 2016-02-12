using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RitualCountdownViewController : ViewControllerBase 
{

    public Text countdownText;

    public void OnEnable()
    {
        SetTheme();
        StartCoroutine(DoCountdown());
    }

    private IEnumerator DoCountdown()
    {
        countdownText.text = "Prepare!";
        yield return new WaitForSeconds(3f);
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
        doRitualView.Ritual = _rituals.CurrentRitual;
        TransitionToView(doRitualView);
    }

    //TODO Set theme is also used in FollowerDoRitual view, wrap somewhere more convenient.
    private void SetTheme() 
    {
        Ritual currentRitual = _rituals.CurrentRitual;
        RitualType currentType = currentRitual.RitualType; 
        ElementTheme elementTheme = _app.ritualTypeMappings.GetThemeForType( currentType );

        _app.themeController.ActivateElement( elementTheme );
    }
}
