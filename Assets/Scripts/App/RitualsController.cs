using UnityEngine;
using System.Collections;

public class RitualsController : MonoBehaviourBase
{
    private Ritual _currentRitual;
    public Ritual CurrentRitual 
    { 
        get 
        {
            return _currentRitual;
        }
        set
        {
            _currentRitual = value;
            _eventSettings.ReportCurrentRitualSet( _currentRitual );
        }
    }

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
