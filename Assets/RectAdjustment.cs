using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectAdjustment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var childCount = 0;
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.active)
                childCount++;
        }
        var scale = this.gameObject.GetComponent<RectTransform>().sizeDelta;
        var properSize = 125 * childCount;
        scale.x = properSize;
        this.gameObject.GetComponent<RectTransform>().sizeDelta = scale;
    }
}
