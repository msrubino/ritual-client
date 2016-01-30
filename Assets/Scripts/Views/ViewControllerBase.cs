using UnityEngine;
using System.Collections;

public abstract class ViewControllerBase : MonoBehaviourBase
{

    protected void TransitionToView(float delay, ViewControllerBase view)
    {
        Delay(delay, () => 
        {
            TransitionToView(view);
        });
    }

    protected void TransitionToView(ViewControllerBase view)
    {
        GameObject.SetActive(false);
        view.GameObject.SetActive(true);
    }

}
