using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class JoinViewController : ViewControllerBase 
{

    public InputField usernameField;
    public Button joinButton;

    public void OnEnable()
    {
        joinButton.onClick.AddListener(Join);
    }

    public void OnDisable()
    {
        joinButton.onClick.RemoveListener(Join);
    }

    private void Join()
    {
        // join logic
        TransitionToView(AppController.Instance.viewReferences.pregameView);
    }

}
