using UnityEngine;
using System;

public abstract class RitualBehaviorBase : MonoBehaviourBase, IRitualBehavior
{

    public event Action DidComplete;

    public abstract void Begin();

    private bool _didComplete;

    protected void Complete()
    {
        if (_didComplete) return;
        _didComplete = true;
        if (DidComplete != null) DidComplete();
    }

}
