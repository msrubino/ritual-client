using UnityEngine;

using System.Collections.Generic;

[RequireComponent(typeof(MicControl))]
public class MakeMicrophoneNoiseRitualBehavior : RitualBehaviorBase {
    #region Fields
    MicControl _micControl;
    List<float> _volumes = new List<float>(1024);

    bool _isRecording;

    [SerializeField]
    float _minLoudness = 0.2f;

    [SerializeField]
    float _maxLoudness = 0.8f;

    [SerializeField]
    float _makeNoiseTimeThreshold = 10f;

    float _makeNoiseSum = 0f;

    float _startTime = 0f;
    #endregion

    #region Methods
    void Awake() 
    {
        _micControl = GetComponent<MicControl>();
        Begin();
    }

    void OnEnable() {
        _micControl.sensitivity = 7f;
    }

    public override void Begin ()
    {
        _startTime = Time.time;
        _isRecording = true; 
    }

    void Update() {
        if (_isRecording) {
            float loudness = _micControl.loudness;
            _volumes.Add(loudness);

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
