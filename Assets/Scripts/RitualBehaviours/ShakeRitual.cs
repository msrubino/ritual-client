using UnityEngine;
using System.Collections;

public class ShakeRitual : RitualBehaviorBase
{

    public float requiredShakeTime;
    public float threshold = 0.5f;

    private float _drumTime;
    private float _lastDrumTime;

    private float _shakeTime;
    public float ShakeTime
    {
        get { return _shakeTime; }
        set 
        { 
            _shakeTime = value; 
            CheckForCompletion();
        }
    }

    float _startTime = 0f;

    public override void Begin() 
    {
        // _drumTime = _audio.SwitchShaker().length;
        _startTime = Time.time;
        ShakeTime = 0f;
    }

    public void Update()
    {
        if (Input.gyro.userAcceleration.magnitude > threshold)
        {
            ShakeTime += Time.deltaTime;
            if (Time.time - _lastDrumTime > _drumTime)
            {
                _drumTime = _audio.SwitchShaker().length;
                _audio.PlaySound( AudioEffectType.TapDrum );
                _lastDrumTime = Time.time;
            }
        }
    }

    private void CheckForCompletion()
    {
        if (ShakeTime >= requiredShakeTime)
        {
            _player.LastPerformanceSpeed = Time.time - _startTime;
            Complete();
        }
    }

}
