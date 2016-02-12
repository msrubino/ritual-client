using UnityEngine;
using System.Collections;

public class WaterEnvironment : ReactiveEnvironment 
{
    public override void OnInputFailed()
    {
    }

    public override void OnInputSuccessful()
    {
        Handheld.Vibrate();
    }
}
