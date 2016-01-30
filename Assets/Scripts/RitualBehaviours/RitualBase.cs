using UnityEngine;
using System;

public abstract class Ritual : MonoBehaviourBase, IRitual
{

    public event Action DidComplete;

    public abstract void Begin();

}
