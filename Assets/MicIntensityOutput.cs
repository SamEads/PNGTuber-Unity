using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicIntensityOutput : MonoBehaviour
{

    public InfoHandler infoHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var anchorMaxIntensity = this.gameObject.GetComponent<RectTransform>().anchorMax;
        anchorMaxIntensity.y = LevelMax();
        this.gameObject.GetComponent<RectTransform>().anchorMax = anchorMaxIntensity;

        if (LevelMax() > infoHandler.minMicOutput)
        {
            this.gameObject.GetComponent<Image>().color = Color.green;
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = Color.red;
        }
    }

    // Get data from microphone into audio clip
    private float LevelMax()
    {
        int dec = 2048;
        float[] waveData = new float[dec];
        int micPosition = Microphone.GetPosition(infoHandler.curMicrophone) - (dec + 1);

        if (micPosition < 0 || infoHandler.microphoneInput == null)
            return 0;

        infoHandler.microphoneInput.GetData(waveData, micPosition);

        // Getting a peak on the last 128 samples
        float levelMax = 0;
        for (int i = 0; i < dec; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
                levelMax = wavePeak;
        }
        float level = Mathf.Sqrt(Mathf.Sqrt(levelMax));
        return level;
    }
}
