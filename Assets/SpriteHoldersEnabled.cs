using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteHoldersEnabled : MonoBehaviour
{
    public Toggle blinkToggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(1).gameObject.SetActive(blinkToggle.isOn);
        transform.GetChild(3).gameObject.SetActive(blinkToggle.isOn);
    }
}
