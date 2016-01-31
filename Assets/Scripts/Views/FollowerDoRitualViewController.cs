using UnityEngine;
using System.Collections;

public class FollowerDoRitualViewController : ViewControllerBase 
{

    private RitualBehaviorBase _ritualBehavior;
    private bool _didCompleteOrTimeout;
    private float _startTime;
    private bool _isSubscribedToRitualDidComplete;

    private Ritual _ritual;
    public Ritual Ritual
    {
        set { _ritual = value; }
    }

    public void Start()
    {
        _startTime = Time.time;
        CreateRitualObject();
        StartCoroutine(CheckForTimeout());
        BeginRitual();
    }

    private void CreateRitualObject()
    {
        var ritualBehavior = AppController.Instance.ritualTypeMappings.GetRitualForType(_ritual.RitualType);
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
        return Time.time - _startTime >= _ritual.TimeUntilStart;
    }

    private void Timeout()
    {
        _didCompleteOrTimeout = true;
        UnsubscribeToRitualDidComplete();
        CheckForResult();
    }

    private void CheckForResult()
    {
        // check for result
        AdvanceToAnnounceRoundWinner();
    }

    private void RitualDidComplete()
    {
        if (_didCompleteOrTimeout) return;
        _didCompleteOrTimeout = true;
        // TODO post ritual result
        // TODO parse ritual result response
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
        Destroy(_ritualBehavior.gameObject);
        var ritualComplete = AppController.Instance.viewReferences.followerRitualCompleteView as FollowerRitualCompleteViewController;
        ritualComplete.TimeToCheckForResult = _startTime + _ritual.TimeUntilStart;
        TransitionToView(ritualComplete);
    }

    private void AdvanceToAnnounceRoundWinner()
    {
        TransitionToView(AppController.Instance.viewReferences.announceRoundWinnerView);
    }

}
