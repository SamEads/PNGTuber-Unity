using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicCooldown : MonoBehaviour
{
    public InfoHandler infoHandler;
    public MicIntensityOutput micIntensityOutput;
    public Slider micCoolDownSlider;
    public float coolDownTime = 0;
    public Image slider;

    public CharacterHandler charHandler;

    void Start()
    {
        infoHandler.updateMicCooldown(micCoolDownSlider.value);
    }

    void Update()
    {
        // If the microphone level is below the threshold
        if (micIntensityOutput.currentIntensity < infoHandler.minMicOutput)
        {
            if (coolDownTime > 0)
            {
                coolDownTime -= (Time.deltaTime);
                if (coolDownTime < infoHandler.cooldownTime)
                {
                    // Is idle
                }
            }
        }
        else
        {
            coolDownTime = 1.25f;
        }

        float intendedAlpha = 1;
        var color = slider.color;
        if (coolDownTime < infoHandler.cooldownTime)
        {
            intendedAlpha = 0.5f;
        }
        charHandler.SetTalkingState(coolDownTime >= infoHandler.cooldownTime);
        color.a = intendedAlpha;
        slider.color = color;

        var anchorMaxIntensity = this.gameObject.GetComponent<RectTransform>().anchorMax;
        anchorMaxIntensity.y = Math.Min(coolDownTime, 1);
        this.gameObject.GetComponent<RectTransform>().anchorMax = anchorMaxIntensity;

        infoHandler.updateMicCooldown(micCoolDownSlider.value);
    }
}
