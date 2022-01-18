using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInputField : CustomButton
{
    public KeyCode savedKey;
    public Text keyText;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        gameObject.GetComponent<VerticalLayoutGroup>().spacing = 0;
        if (keyText.text != savedKey.ToString())
        {
            keyText.text = savedKey.ToString();
            gameObject.GetComponent<VerticalLayoutGroup>().spacing = 0.001f;
        }
    }
}
