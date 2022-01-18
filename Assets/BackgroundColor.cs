using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundColor : MonoBehaviour
{
    public Camera cam;
    private Slider[] sliders;

    // Start is called before the first frame update
    void Start()
    {
        sliders = new Slider[transform.childCount];
        for (int i = 0; i < sliders.Length; i++)
            sliders[i] = transform.GetChild(i).GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Color bgc = cam.backgroundColor;
        bgc.r = sliders[0].value;
        bgc.g = sliders[1].value;
        bgc.b = sliders[2].value;
        cam.backgroundColor = bgc;
    }
}
