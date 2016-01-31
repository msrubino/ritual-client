﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : MonoBehaviourBase {
    
    public AudioSource sfxAudioSource;
    public AudioSource touchAudioSource;
    public AudioSource drumSource;

    private AudioClip _myDrum;

    public AudioClip[] viewSwitchClips;
    AudioClip[] _drumClips;
    
    void Awake()
    {
        LoadDrums();
    }

    void OnEnable()
    {
        _inputSettings.OnTouchBegan += OnTouchBegan;
        _inputSettings.OnTouchEnded += OnTouchEnded;
    }

    void OnDisable()
    {
        _inputSettings.OnTouchBegan -= OnTouchBegan;
        _inputSettings.OnTouchEnded -= OnTouchEnded;
    }

    public void PlaySound( AudioClip clip )
    {
        //Temp.
        sfxAudioSource.PlayOneShot( clip );
    }

    public void PlaySound( AudioEffectType type )
    {
        AudioClip clipToPlay = null;
        AudioSource audSource = sfxAudioSource;

        switch( type )
        {
            case ( AudioEffectType.ViewSwitch ):
                clipToPlay = viewSwitchClips[ Random.Range( 0, viewSwitchClips.Length ) ];
            break;

            case ( AudioEffectType.TapDrum ):
                if ( drumSource.isPlaying ) return;
                clipToPlay = _myDrum; //_drumClips[ Random.Range( 0, _drumClips.Length ) ];
                audSource = drumSource;
            break;

            default:
                
            break;
        }

        audSource.PlayOneShot( clipToPlay );
    }

    public void OnTouchBegan( TouchInfo ti )
    {
        //Debug.Log("OnTouchBegan");   
    }
    
    public void OnTouchEnded( TouchInfo ti )
    {
        //Debug.Log("OnTouchEnded");   
    }

    public void SwitchDrum()
    {
        _myDrum = _drumClips[ Random.Range( 0, _drumClips.Length ) ];
    }

    void LoadDrums()
    {
        _drumClips = Resources.LoadAll("drums") as AudioClip[]; 
        Debug.Log( _drumClips );
    }
}

public enum AudioEffectType
{
    TapDrum,
    ViewSwitch
}
