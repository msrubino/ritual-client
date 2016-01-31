using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
    
    public AudioSource sfxAudioSource;
    
    public void PlaySound( AudioClip clip )
    {
        //Temp.
        sfxAudioSource.PlayOneShot( clip );
    }
}
