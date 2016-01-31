using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoHud : MonoBehaviourBase 
{
    public Transform textHolder;
    public InfoHudText textPrefab;
    public Text textField;

    public void Log( string s )
    {
        textField.text = s;
        InfoHudText newText = textHolder.InstantiateChild( textPrefab );
        newText.SetText( s );
    }
}
