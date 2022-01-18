using SFB;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpriteHolder : CustomButton
{

    public string fileOpenText = "Open File";

    [HideInInspector]
    public List<Sprite> myLoadedSprites = new List<Sprite>();

    public GameObject displaySpriteObject;
    public Sprite defaultSprite;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        myLoadedSprites.Add(defaultSprite);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        displaySpriteObject.GetComponent<Image>().sprite = myLoadedSprites[0];
    }

    public override void OnLeftClick()
    {
        StartCoroutine(LoadImages());
    }

    private IEnumerator LoadImages()
    {
        var extensions = new[]
        {
            new ExtensionFilter("Image Files", "gif", "png", "jpg", "jpeg")
        };
        var chosenPaths = StandaloneFileBrowser.OpenFilePanel(fileOpenText, "", extensions, false);
        if (chosenPaths.Length != 0)
        {
            WWW www = new WWW(chosenPaths[0]);
            yield return www;

            Texture2D texTmp = new Texture2D(1024, 1024, TextureFormat.DXT1, false);
            www.LoadImageIntoTexture(texTmp);

            // The sprite to create and load
            foreach (var spr in myLoadedSprites)
            {
                Sprite.Destroy(spr);
            }
            myLoadedSprites.Clear();
            myLoadedSprites.Add(Sprite.Create(texTmp, new Rect(0, 0, texTmp.width, texTmp.height), new Vector2(0.5f, 0.5f), 100f));
        }
        else
        {
            Debug.Log("No valid files to load");
        }
    }
}
