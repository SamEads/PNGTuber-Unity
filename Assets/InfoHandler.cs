using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHandler : MonoBehaviour
{

    public string curMicrophone;
    public AudioClip microphoneInput = null;
    public float minMicOutput = 0.35f;

    // Start is called before the first frame update
    void Start()
    {
        // Set to first microphone
        ChangeMicrophone(0);
    }

    // Set microphone to new option
    public void ChangeMicrophone(int newMicValue)
    {
        curMicrophone = Microphone.devices[newMicValue];
        microphoneInput = Microphone.Start(curMicrophone, true, 999, 44100);
    }

    public void updateMicIntensity(float newIntensity)
    {
        this.minMicOutput = newIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
