﻿using UnityEngine;
using System.Collections;

public class FollowerDoRitualViewController : ViewControllerBase 
{

    private RitualBehaviorBase _ritualBehavior;
    private bool _didCompleteOrTimeout;
    private float _startTime;
    private bool _isSubscribedToRitualDidComplete;

    private Coroutine _checkForTimeout;

    private Ritual _ritual;
    public Ritual Ritual
    {
        set { _ritual = value; }
    }

    public void OnEnable()
    {
        _didCompleteOrTimeout = false;
        _startTime = Time.time;

        CreateRitualObject();
        _checkForTimeout = StartCoroutine(CheckForTimeout());
        BeginRitual();
    }

    public void OnDisable() 
    {
        Destroy(_ritualBehavior.gameObject);
    }

    private void CreateRitualObject()
    {
        var ritualBehavior = AppController.Instance.ritualTypeMappings.GetRitualBehaviorForType(_ritual.RitualType);
        _ritualBehavior = Instantiate(ritualBehavior, Vector3.zero, Quaternion.identity) as RitualBehaviorBase;
    }
    
    private void BeginRitual()
    {
        SubscribeToRitualDidComplete();
        _ritualBehavior.Begin();
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
        return Time.unscaledTime - _startTime >= _ritual.Duration;
    }

    private void Timeout()
    {
        _didCompleteOrTimeout = true;
        UnsubscribeToRitualDidComplete();
        StartCoroutine(CheckForResult());
    }

    private IEnumerator CheckForResult()
    {
        yield return StartCoroutine(_api.RitualResults());
        AdvanceToAnnounceRoundWinner();
    }

    private void RitualDidComplete()
    {
        if (_didCompleteOrTimeout) return;
        _didCompleteOrTimeout = true;

        if (_checkForTimeout != null) 
        {
            StopCoroutine(_checkForTimeout);
            _checkForTimeout = null;
        }

        StartCoroutine(PostResult());
    }

    private IEnumerator PostResult() {
        yield return StartCoroutine(_api.PerformedRitual());
        AdvanceToRitualComplete();
    }

    private void SubscribeToRitualDidComplete()
    {
        if (_isSubscribedToRitualDidComplete) return;
        _isSubscribedToRitualDidComplete = true;
        _ritualBehavior.DidComplete += RitualDidComplete;
    }

    private void UnsubscribeToRitualDidComplete()
    {
        if (!_isSubscribedToRitualDidComplete) return;
        _isSubscribedToRitualDidComplete = false;
        _ritualBehavior.DidComplete -= RitualDidComplete;
    }

    private void AdvanceToRitualComplete()
    {
        var ritualComplete = AppController.Instance.viewReferences.followerRitualCompleteView as FollowerRitualCompleteViewController;
        ritualComplete.TimeToCheckForResult = _startTime + _ritual.TimeUntilStart;
        TransitionToView(ritualComplete);
    }

    private void AdvanceToAnnounceRoundWinner()
    {
        TransitionToView(AppController.Instance.viewReferences.announceRoundWinnerView);
    }

}
