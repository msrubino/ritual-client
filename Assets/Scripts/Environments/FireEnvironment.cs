using UnityEngine;
using System.Collections;

public class FireEnvironment : ReactiveEnvironment 
{
    public ParticleSystem volcanoSpout;

    public override void OnInputFailed()
    {
        volcanoSpout.Pause();        
    }

    public override void OnInputSuccessful()
    {
        if ( !volcanoSpout.isPlaying ) volcanoSpout.Play();        
        Handheld.Vibrate();
    }
}
