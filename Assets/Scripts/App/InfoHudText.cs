using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoHudText : MonoBehaviour 
{
    public Text text;

    public void SetText( string s )
    {
        text.text = s;

        Color clearColor = Colors.GetClearColor( text.color );
        var config = new GoTweenConfig().colorProp( "color", clearColor ).onComplete( ( tween ) => Destroy( this.gameObject ) );
        Go.to( text, 5f, config );
    }
}
