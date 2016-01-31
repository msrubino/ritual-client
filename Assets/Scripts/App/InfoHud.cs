using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoHud : MonoBehaviourBase 
{
    public Text textField;

    public void Log( string s )
    {
        textField.text = s;
    }
}
