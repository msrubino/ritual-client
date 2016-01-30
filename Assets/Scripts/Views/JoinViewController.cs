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
        StartCoroutine( DoJoin() );
    }

    private IEnumerator DoJoin()
    {
        // join logic
        // Create the Join request.
        // Pass name in.
        // Pass UUID in.
        WWW request = CreateJoinPOSTRequest();

        yield return request;

        TransitionToView(AppController.Instance.viewReferences.pregameView);
    }

    private WWW CreateJoinPOSTRequest()
    {
        _player.Username = usernameField.text; 

        WWWForm form = new WWWForm(); 
        form.AddField( "uuid", _player.Uuid );
        form.AddField( "name", _player.Username );
        
        string url = _www.joinURL;
        return new WWW( url, form );

    }
}
