using UnityEngine;
using System.Collections;

public class RitualsController : MonoBehaviour 
{
    public Ritual CurrentRitual { get; set; }

    public void SetCurrentRitual( RitualObj ritualObj )
    {
        //TODO How to set the current ritual properly, translating to Ritual from ritualObj
        //CurrentRitual 
    }

    public bool WaitingForCurrentRitualToFinish()
    {
      if ( CurrentRitual == null ) return false;
      //TODO Check if duration is over?
      
      return true;
    }
}
