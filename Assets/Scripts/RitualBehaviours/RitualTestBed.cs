using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class RitualTestBed : MonoBehaviour
{

    public event Action OnRitualDidComplete;
    public event Action OnRitualDidTimeout;

    public RitualType ritualType;
    public RitualTypeMappings mappings;
    public Text text;
    public Text buttonText;

    private RitualBehaviorBase _ritualBehavior;
    private RitualBehaviorBase _instantiatedRitualBehavior;
    private bool _didCompleteOrTimeout;
    private float _startTime;
    private bool _isSubscribedToRitualDidComplete;
    private float _duration;
    private Coroutine _checkForTimeout;
    private bool _isStarted;

    public void OnEnable()
    {
        var mapping = mappings.GetMappingForType(ritualType);
        _duration = mapping.duration;
        _ritualBehavior = mapping.ritualBehavior;
    }

    public void OnButtonClick()
    {
        if (!_isStarted) StartRitual();
        else RestartRitual();
    }

    private void StartRitual()
    {
        _isStarted = true;
        _didCompleteOrTimeout = false;
        _startTime = Time.time;
        buttonText.text = "Restart";
        CreateRitualObject();
        _checkForTimeout = StartCoroutine(CheckForTimeout());
        BeginRitual();
    }

    private void RestartRitual()
    {
        UnsubscribeToRitualDidComplete();
        if (_instantiatedRitualBehavior != null && _instantiatedRitualBehavior.gameObject != null) Destroy(_instantiatedRitualBehavior.gameObject);
        StartRitual();
    }

    public void OnDisable() 
    {
        if (_instantiatedRitualBehavior != null && _instantiatedRitualBehavior.gameObject != null) Destroy(_instantiatedRitualBehavior.gameObject);
    }

    private void CreateRitualObject()
    {
        _instantiatedRitualBehavior = Instantiate(_ritualBehavior, Vector3.zero, Quaternion.identity) as RitualBehaviorBase;
    }
    
    private void BeginRitual()
    {
        SubscribeToRitualDidComplete();
        _instantiatedRitualBehavior.Begin();
    }

    public void Update()
    {
        if (_didCompleteOrTimeout || !_isStarted) return;
        text.text = string.Format("{0:0.0}", Time.unscaledTime - _startTime);
    }

    private IEnumerator CheckForTimeout()
    {
        while (true)
        {
            if (_didCompleteOrTimeout) yield break;
            if (HasTimedOut())
            {
                Timeout();
                yield break;
            }
            yield return null;
        }
    }

    private bool HasTimedOut()
    {
        return Time.time - _startTime >= _duration;
    }

    private void Timeout()
    {
        text.text = "Timed Out!";
        _didCompleteOrTimeout = true;
        UnsubscribeToRitualDidComplete();
        if (OnRitualDidTimeout != null) OnRitualDidTimeout();
    }

    private void RitualDidComplete()
    {
        if (_didCompleteOrTimeout) return;
        if (OnRitualDidComplete != null) OnRitualDidComplete();
        _didCompleteOrTimeout = true;
        text.text = "Complete";
        if (_checkForTimeout != null) 
        {
            StopCoroutine(_checkForTimeout);
            _checkForTimeout = null;
        }
    }

    private void SubscribeToRitualDidComplete()
    {
        if (_isSubscribedToRitualDidComplete) return;
        _isSubscribedToRitualDidComplete = true;
        _instantiatedRitualBehavior.DidComplete += RitualDidComplete;
    }

    private void UnsubscribeToRitualDidComplete()
    {
        if (!_isSubscribedToRitualDidComplete) return;
        _isSubscribedToRitualDidComplete = false;
        _instantiatedRitualBehavior.DidComplete -= RitualDidComplete;
    }



}
