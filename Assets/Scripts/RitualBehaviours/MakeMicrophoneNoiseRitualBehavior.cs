using UnityEngine;
using System.Collections.Generic;

public class MakeMicrophoneNoiseRitualBehavior : RitualBehaviorBase {
    #region Fields
    MicControlC _micControl;
    List<float> _volumes = new List<float>(1024);

    bool _isRecording;

    [SerializeField]
    float _minLoudness = 50f;

    [SerializeField]
    float _maxLoudness = 10000f;

    [SerializeField]
    float _makeNoiseTimeThreshold = 5f;

    float _makeNoiseSum = 0f;

    float _startTime = 0f;
    #endregion

    #region Methods
    void Awake() 
    {
        _micControl = GetComponent<MicControlC>();
        Begin();
    }

    public override void Begin ()
    {
        _startTime = Time.time;
        _isRecording = true; 
    }

    void Update() {
        if (_isRecording) {
            float loudness = _micControl.loudness;
            if (loudness > _minLoudness && loudness < _maxLoudness) 
            {
                _makeNoiseSum += Time.unscaledDeltaTime;
            }

            if (_makeNoiseSum >= _makeNoiseTimeThreshold) 
            {
                _player.LastPerformanceSpeed = Time.time - _startTime;
                Complete();
            }
        }
    }
    #endregion
}
