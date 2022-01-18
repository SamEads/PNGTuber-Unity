using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHandler : MonoBehaviour
{

    [HideInInspector]
    public string curMicrophone;
    [HideInInspector]
    public float minMicOutput;
    [HideInInspector]
    public float cooldownTime;
    [HideInInspector]
    public bool characterBlink = true;
    [HideInInspector]
    public AudioClip microphoneInput = null;

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

    public void updateMicCooldown(float newCooldown)
    {
        this.cooldownTime = newCooldown;
    }

    public void changeBlink(bool blinkState)
    {
        this.characterBlink = blinkState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
