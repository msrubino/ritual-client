using UnityEngine;
using System.Collections;

public abstract class ViewControllerBase : MonoBehaviourBase
{

    protected void TransitionToView(ViewControllerBase view)
    {
        GameObject.SetActive(false);
        view.GameObject.SetActive(true);
    }

}
