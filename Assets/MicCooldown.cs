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
    public Image slider;
    public RectTransform CooldownRectangle;
    public CharacterHandler charHandler;
    public float coolDownTime = 0;

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
            }
        }
        else
        {
            coolDownTime = 1.125f;
        }

        charHandler.SetTalkingState(coolDownTime >= infoHandler.cooldownTime);

        // Handle bar color
        float intendedAlpha = 1;
        var color = slider.color;
        if (coolDownTime < infoHandler.cooldownTime)
        {
            intendedAlpha = Math.Max(0.4f, slider.color.a - (3f * Time.deltaTime));
        }
        color.a = intendedAlpha;
        slider.color = color;

        var anchorMaxIntensity = CooldownRectangle.anchorMax;
        anchorMaxIntensity.y = Math.Min(coolDownTime, 1);
        CooldownRectangle.anchorMax = anchorMaxIntensity;

        infoHandler.updateMicCooldown(micCoolDownSlider.value);
    }
}
