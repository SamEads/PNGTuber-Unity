using SFB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FileHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ImageClick(PointerEventData buttonInformation)
    {
        // Left click
        if (buttonInformation.button == PointerEventData.InputButton.Left)
        {
            StartCoroutine(LoadImages());
        }
    }

    private IEnumerator LoadImages()
    {
        var extensions = new[] {
            new ExtensionFilter("Image Files", "gif", "png", "jpg", "jpeg"),
        };
        var chosenPaths = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, false);
        if (chosenPaths.Length != 0)
        {
            WWW www = new WWW(chosenPaths[0]);
            yield return www;
            Texture2D texTmp = new Texture2D(1024, 1024, TextureFormat.DXT1, false);
            www.LoadImageIntoTexture(texTmp);

            // The sprite to create and load
            //var spr = Sprite.Create(texTmp, new Rect(0, 0, texTmp.width, texTmp.height), new Vector2(0.5f, 0.5f), 100f);
        }
        else
        {
            Debug.Log("No valid files to load");
        }
    }
}
