using UnityEngine;
using System;
using System.Collections;

public class EventSettings : Settings<EventSettings> 
{
    public static void DefaultAction( Ritual ritual ){}

    public event Action<Ritual> OnCurrentRitualSet = DefaultAction;
    public void ReportCurrentRitualSet( Ritual ritual ) { OnCurrentRitualSet( ritual ); }

    public event Action OnInputFailed = DefaultAction;
    public void ReportInputFailed() { OnInputFailed(); }

    public event Action OnInputSuccessful = DefaultAction;
    public void ReportInputSuccessful() { OnInputSuccessful(); }

    
}
