using UnityEngine;
using System.Collections;

public class TapRitual : RitualBehaviorBase
{

    public int numberOfTaps;
    
    private int _tapCount;
    public int TapCount
    {
        get { return _tapCount; }
        set 
        { 
            _tapCount = value; 
            CheckForCompletion();
        }
    }

    float _startTime = 0f;

    public override void Begin() 
    {
        _audio.SwitchDrum();
        _startTime = Time.time;
        TapCount = 0; 
    }

    public void OnMouseDown()
    {
        TapCount++;
        _audio.PlaySound( AudioEffectType.TapDrum );
    }

    private void CheckForCompletion()
    {
        if (TapCount >= numberOfTaps)
        {
            _player.LastPerformanceSpeed = Time.time - _startTime;
            Complete();
        }
    }

}
