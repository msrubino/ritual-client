using UnityEngine;
using System.Collections;
 
[RequireComponent(typeof(AudioSource))]
public class MicControlC : MonoBehaviour {
 
    public float sensitivity = 100;
    public float ramFlushSpeed = 5;//The smaller the number the faster it flush's the ram, but there might be performance issues...
    [Range(0,100)]
    public float sourceVolume = 100;//Between 0 and 100
    //
    public string selectedDevice { get; private set; }  
    public float loudness { get; private set; } //dont touch
    //
    private bool micSelected = false;
    private float ramFlushTimer;
    private int amountSamples = 256; //increase to get better average, but will decrease performance. Best to leave it
    private int minFreq, maxFreq; 
 
    void Start() {
        GetComponent<AudioSource>().loop = true; // Set the AudioClip to loop
        GetComponent<AudioSource>().mute = false; // Mute the sound, we don't want the player to hear it
        selectedDevice = Microphone.devices[0].ToString();
        micSelected = true;
        GetMicCaps();
    }

    public void GetMicCaps () {
        Microphone.GetDeviceCaps(selectedDevice, out minFreq, out maxFreq);//Gets the frequency of the device
        if ((minFreq + maxFreq) == 0)//These 2 lines of code are mainly for windows computers
            maxFreq = 44100;
    }
 
    public void StartMicrophone () {
        GetComponent<AudioSource>().clip = Microphone.Start(selectedDevice, true, 10, maxFreq);//Starts recording
        while (!(Microphone.GetPosition(selectedDevice) > 0)){} // Wait until the recording has started
        GetComponent<AudioSource>().Play(); // Play the audio source!
    }
 
    public void StopMicrophone () {
        GetComponent<AudioSource>().Stop();//Stops the audio
        Microphone.End(selectedDevice);//Stops the recording of the device  
    }       
 
    void Update() {
        GetComponent<AudioSource>().volume = (sourceVolume/100);
        loudness = GetAveragedVolume() * sensitivity * (sourceVolume/10);

        if (!Microphone.IsRecording(selectedDevice)) 
                StartMicrophone();

    }
 
    private void RamFlush () {
        if (ramFlushTimer >= ramFlushSpeed && Microphone.IsRecording(selectedDevice)) {
            StopMicrophone();
            StartMicrophone();
            ramFlushTimer = 0;
        }
    }
 
    float GetAveragedVolume() {
        float[] data = new float[amountSamples];
        float a = 0;
        GetComponent<AudioSource>().GetOutputData(data,0);
        foreach(float s in data) {
            a += Mathf.Abs(s);
        }
        return a/amountSamples;
    }
}