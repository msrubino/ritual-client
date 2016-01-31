using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoHudText : MonoBehaviour 
{
    public Text text;

    public void SetText( string s )
    {
        text.text = s;
    }
}
