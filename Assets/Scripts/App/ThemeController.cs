﻿using UnityEngine;
using System.Collections;
using System.Linq;

public class ThemeController : MonoBehaviourBase
{
    public ElementGroup[] elementGroups;
    
    public void ActivateElement( ElementTheme element )
    {
        ElementGroup group = elementGroups.FirstOrDefault( eg => eg.element == element ); 
        if ( group == null ) return;

        _audio.PlaySound( group.mainSFX );
    }

    [ContextMenu("Select Random Element")]
    public void SelectRandomElement()
    {
        ActivateElement( elementGroups[ Random.Range( 0, elementGroups.Length ) ].element );
    }
}

[System.Serializable]
public class ElementGroup
{
    public ElementTheme element;
    public AudioClip mainSFX;
    public GameObject backgroundEnvironment;
}

public enum ElementTheme
{
    Air,
    Earth,
    Fire,
    Water
}