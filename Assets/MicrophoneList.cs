using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MicrophoneList : MonoBehaviour
{
    public Dropdown dropDown;
    // Start is called before the first frame update
    void Start()
    {
        List<string> micList = Microphone.devices.ToList();
        dropDown.AddOptions(micList);
    }
}
