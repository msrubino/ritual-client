using UnityEngine;
using System.Collections;

public class FollowerRitualCompleteViewController : ViewControllerBase
{

    public void Start()
    {
        PollForRoundOver();
    }

    private void PollForRoundOver()
    {
        // poll
        // if round over
        ParseResponse();
        // else
        // PollForRoundOver();
    }

    private void ParseResponse()
    {
        // if reign over
        // HandleReignOver();
        // else
        // HandleRoundOver()
    }

    private void HandleReignOver()
    {
        // if won reign
        // AdvanceToWonReign();
        // else
        // AdvanceToAnnounceReignWinner();
    }

    private void HandleRoundOver()
    {
        // if won round
        // AdvanceToWonRound();
        // else 
        // AdvanceToAnnounceRoundWinner();
    }

    private void AdvanceToWonReign()
    {
        TransitionToView(AppController.Instance.viewReferences.wonReignView);
    }

    private void AdvanceToAnnounceReignWinner()
    {
        TransitionToView(AppController.Instance.viewReferences.announceReignWinnerView);
    }

    private void AdvanceToWonRound()
    {
        TransitionToView(AppController.Instance.viewReferences.wonRoundView);
    }

    private void AdvanceToAnnounceRoundWinner()
    {
        TransitionToView(AppController.Instance.viewReferences.announceRoundWinnerView);
    }

}
