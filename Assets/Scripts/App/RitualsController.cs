using UnityEngine;
using System.Collections;

public class RitualsController : MonoBehaviourBase
{
    public Ritual CurrentRitual { get; set; }
    public Ritual CurrentPollRitual { get; set; }

    public bool HasCurrentActiveRitual()
    {
        return CurrentRitual != null && CurrentRitual.IsActive;
    }

    public void SetCurrentRitual( Ritual ritual) 
    {
        _rituals.CurrentRitual = ritual;
    }

    public void SetCurrentPollRitual( Ritual ritual )
    {
        _rituals.CurrentPollRitual = ritual;
    }

    public bool WaitingForCurrentRitualToFinish()
    {
      if ( CurrentRitual == null ) return false;
      //TODO Check if duration is over?
      
      return true;
    }
}
