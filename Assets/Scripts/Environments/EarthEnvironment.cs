using UnityEngine;
using System.Collections;

public class EarthEnvironment : ReactiveEnvironment 
{
    public override void OnInputFailed()
    {
    }

    public override void OnInputSuccessful()
    {
        Handheld.Vibrate();
    }
}
