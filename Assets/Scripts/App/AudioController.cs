using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviourBase {
    
    public AudioSource sfxAudioSource;
    public AudioSource touchAudioSource;
    public AudioClip[] viewSwitchClips;
    
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

        switch( type )
        {
            case ( AudioEffectType.ViewSwitch ):
                clipToPlay = viewSwitchClips[ Random.Range( 0, viewSwitchClips.Length ) ];
            break;

            default:
            break;
        }

        sfxAudioSource.PlayOneShot( clipToPlay );
    }

    public void OnTouchBegan( TouchInfo ti )
    {
        //Debug.Log("OnTouchBegan");   
    }
    
    public void OnTouchEnded( TouchInfo ti )
    {
        //Debug.Log("OnTouchEnded");   
    }
}

public enum AudioEffectType
{
    ViewSwitch
}
