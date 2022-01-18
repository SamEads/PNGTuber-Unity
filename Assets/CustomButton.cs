using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected Image buttonImage;
    protected Color aimedColor = Color.white;
    protected Color hoverColor = new Color(0.8f, 0.8f, 0.8f);
    protected Color clickColor = new Color(0.5f, 0.5f, 0.5f);

    // Start is called before the first frame update
    public virtual void Start()
    {
        buttonImage = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        buttonImage.color = Color.Lerp(buttonImage.color, aimedColor, 10f * Time.deltaTime);
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

    public void OnPointerEnter(PointerEventData eventData) => aimedColor = hoverColor;
    public void OnPointerExit(PointerEventData eventData) => aimedColor = Color.white;

    public virtual void OnLeftClick()
    {

    }

    public virtual void OnRightClick()
    {

    }

}
