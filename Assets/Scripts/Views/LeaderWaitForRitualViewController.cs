﻿using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class LeaderWaitForRitualViewController : ViewControllerBase
{
    [SerializeField]
    Text _informFollowers;

    private float _duration;
    public float Duration
    {
        set { _duration = value; }
    }

    public string LeaderInstructions { get; set; }
    public ElementTheme CurrentTheme { get; set; }

    public void OnEnable()
    {
        _informFollowers.text = string.Format("Guide Your followers:\n{0}", LeaderInstructions);
        DelayedCheckForResult();
    }

    private void DelayedCheckForResult()
    {
        Delay(_duration, () => {
            StartCoroutine(CheckForResult());
        });
    }

    private IEnumerator CheckForResult()
    {
         yield return StartCoroutine(_api.RitualResults());
         AdvanceToAnnounceRoundWinner();
    }

    private void AdvanceToAnnounceRoundWinner()
    {
        _app.themeController.DeactivateElement(CurrentTheme);
        TransitionToView(AppController.Instance.viewReferences.announceRoundWinnerView);
    }
}
