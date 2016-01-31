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
    float _makeNoiseTimeThreshold = 3f;

    float _makeNoiseSum = 0f;
    #endregion

    #region Methods
    void Awake() {
        _micControl = GetComponent<MicControl>();

        Begin();
    }

    public override void Begin ()
    {
        _isRecording = true; 
    }

    void Update() {
        Debug.Log(_micControl.loudness);

        if (_isRecording) {
            float loudness = _micControl.loudness;
            _volumes.Add(loudness);

            if (loudness > _minLoudness && loudness < _maxLoudness) {
                _makeNoiseSum += Time.unscaledDeltaTime;
            }

            if (_makeNoiseSum >= _makeNoiseTimeThreshold) {
                Complete();
            }
        }
    }
    #endregion
}
