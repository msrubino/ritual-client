using UnityEngine;
using System.Collections;

public class ReactiveEnvironment : MonoBehaviourBase 
{
    void OnEnable()
    {
        _eventSettings.OnInputFailed += OnInputFailed;    
        _eventSettings.OnInputSuccessful += OnInputSuccessful;    
    }

    void OnDisable()
    {
        _eventSettings.OnInputFailed -= OnInputFailed;    
        _eventSettings.OnInputSuccessful -= OnInputSuccessful;    
    }

    public virtual void OnInputFailed(){}
    public virtual void OnInputSuccessful(){}
}
