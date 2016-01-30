using UnityEngine;
using System;

public abstract class RitualBehaviorBase : MonoBehaviourBase, IRitualBehavior
{

    public event Action DidComplete;

    public abstract void Begin();

}
