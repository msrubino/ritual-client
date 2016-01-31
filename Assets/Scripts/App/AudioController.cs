using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
    
    public AudioSource sfxAudioSource;
    public AudioClip[] viewSwitchClips;
    
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
}

public enum AudioEffectType
{
    ViewSwitch
}
