﻿using UnityEngine;
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
            Debug.Log( "Waiting for current ritual to finish." );
            AdvanceToPregame();
        } 
        else 
        {
            if ( _player.IsLeader ) 
            {
                Debug.Log( "Going on to be the first leader." );
                AdvanceToFirstLeader();
            }
            else 
            {
                Debug.Log( "Going on to start round." );
                AdvanceToStartRound();
            }
        }
    }

    private void AdvanceToPregame()
    {
        TransitionToView(AppController.Instance.viewReferences.pregameView);
    }

    private void AdvanceToFirstLeader()
    {
        TransitionToView(AppController.Instance.viewReferences.leaderStartRoundView);
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
