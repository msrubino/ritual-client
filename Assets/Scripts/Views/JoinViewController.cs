using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class JoinViewController : ViewControllerBase 
{

    public Text usernameField;
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
        Debug.Log( "Joining." );
        SetUserName();
        StartCoroutine( DoJoin() );
    }

    private IEnumerator DoJoin()
    {
        yield return StartCoroutine( _api.Join() );

        if ( _rituals.WaitingForCurrentRitualToFinish() )
        {
            AdvanceToPregame();
        } else {
            AdvanceToStartRound();
        }
    }

    private void AdvanceToPregame()
    {
        TransitionToView(AppController.Instance.viewReferences.pregameView);
    }

    private void AdvanceToStartRound()
    {
        TransitionToView(AppController.Instance.viewReferences.followerStartRoundView);
    }
    
    private void SetUserName()
    {
        _player.Username = usernameField.text; 
    }
}
