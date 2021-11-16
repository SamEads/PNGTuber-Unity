using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusHandler : MonoBehaviour
{
    [HideInInspector]
    public bool hasFocus = false;

    public CanvasGroup canvasGroup;

    void Update()
    {
        hasFocus = !(!Application.isFocused || Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height);
        //canvasGroup.alpha = (hasFocus) ? 1 : 0;
        canvasGroup.interactable = hasFocus;

        if (hasFocus)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += 6 * Time.deltaTime;
                if (canvasGroup.alpha > 1)
                    canvasGroup.alpha = 1;
            }
        }
        else
        {
            if (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= 6 * Time.deltaTime;
                if (canvasGroup.alpha < 0)
                    canvasGroup.alpha = 0;
            }
        }
    }
}
