using SFB;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpriteHolder : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public string fileOpenText = "Open File";

    [HideInInspector]
    public List<Sprite> myLoadedSprites = new List<Sprite>();

    public GameObject displaySpriteObject;
    public Sprite defaultSprite;

    private Image buttonImage;
    private Color aimedColor = Color.white;

    private Color hoverColor = new Color(0.8f, 0.8f, 0.8f);
    private Color clickColor = new Color(0.5f, 0.5f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = gameObject.GetComponent<Image>();
        myLoadedSprites.Add(defaultSprite);
    }

    // Update is called once per frame
    void Update()
    {
        buttonImage.color = Color.Lerp(buttonImage.color, aimedColor, 10f * Time.deltaTime);
        displaySpriteObject.GetComponent<Image>().sprite = myLoadedSprites[0];
    }

    public void OnPointerClick(PointerEventData buttonData)
    {
        buttonImage.color = clickColor;
        if (buttonData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
        else if (buttonData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        aimedColor = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        aimedColor = Color.white;
    }

    private void OnLeftClick()
    {
        StartCoroutine(LoadImages());
    }

    private void OnRightClick()
    {
        throw new NotImplementedException();
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
