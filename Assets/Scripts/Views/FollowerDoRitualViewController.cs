using UnityEngine;
using System.Collections;

public class FollowerDoRitualViewController : ViewControllerBase 
{

    private Ritual _ritual;
    private bool _didCompleteOrTimeout;
    private float _startTime;
    private bool _isSubscribedToRitualDidComplete;

    private RitualInfo _ritualInfo;
    public RitualInfo RitualInfo
    {
        set { _ritualInfo = value; }
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
        var ritualType = AppController.Instance.ritualTypeMappings.GetRitualForType(_ritualInfo.RitualType);
        _ritual = Instantiate(ritualType, Vector3.zero, Quaternion.identity) as Ritual;
    }
    
    private void BeginRitual()
    {
        SubscribeToRitualDidComplete();
        _ritual.Begin();
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
        return Time.time - _startTime >= _ritualInfo.TimeUntilStart;
    }

    private void Timeout()
    {
        _didCompleteOrTimeout = true;
        UnsubscribeToRitualDidComplete();
        AdvanceToRitualComplete();
    }

    private void RitualDidComplete()
    {
        if (_didCompleteOrTimeout) return;
        _didCompleteOrTimeout = true;
        // post ritual result
        // parse ritual result response
        AdvanceToRitualComplete();
    }

    private void SubscribeToRitualDidComplete()
    {
        if (_isSubscribedToRitualDidComplete) return;
        _isSubscribedToRitualDidComplete = true;
        _ritual.DidComplete += RitualDidComplete;
    }

    private void UnsubscribeToRitualDidComplete()
    {
        if (!_isSubscribedToRitualDidComplete) return;
        _isSubscribedToRitualDidComplete = false;
        _ritual.DidComplete -= RitualDidComplete;
    }

    private void AdvanceToRitualComplete()
    {
        Destroy(_ritual.gameObject);
        var ritualComplete = AppController.Instance.viewReferences.followerRitualCompleteView as FollowerRitualCompleteViewController;
        ritualComplete.TimeToCheckForResult = _startTime + _ritualInfo.TimeUntilStart;
        TransitionToView(ritualComplete);
    }

}
