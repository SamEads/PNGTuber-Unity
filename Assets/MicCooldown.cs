using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicCooldown : MonoBehaviour
{
    public InfoHandler infoHandler;
    public MicIntensityOutput micIntensityOutput;
    public Slider micIntensitySlider;
    public float coolDownTime = 0;

    void Start()
    {
        infoHandler.updateMicCooldown(micIntensitySlider.value);
    }

    void Update()
    {
        // If the microphone level is below the threshold
        if (micIntensityOutput.currentIntensity < infoHandler.minMicOutput)
        {
            if (coolDownTime > 0)
            {
                coolDownTime-= (Time.deltaTime * ((infoHandler.cooldownTime*10)+1));
                if (coolDownTime < 0)
                    coolDownTime = 0;
            }
        }
        else
        {
            coolDownTime = 1;
        }

        var anchorMaxIntensity = this.gameObject.GetComponent<RectTransform>().anchorMax;
        anchorMaxIntensity.y = coolDownTime;
        this.gameObject.GetComponent<RectTransform>().anchorMax = anchorMaxIntensity;
    }
}
