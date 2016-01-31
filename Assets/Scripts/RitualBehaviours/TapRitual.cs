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

    public override void Begin() 
    {
        _audio.SwitchDrum();
        TapCount = 0; 
    }

    public void OnMouseDown()
    {
        TapCount++;
    }

    private void CheckForCompletion()
    {
        if (TapCount >= numberOfTaps)
        {
            Complete();
        }
    }

}
