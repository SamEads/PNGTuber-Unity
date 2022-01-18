using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHandler : MonoBehaviour
{
    public GameObject spriteHolders;
    private SpriteHolder[] charSprites;
    public Animator animator;
    public Toggle blinkToggle;

    [HideInInspector]
    public bool isTalking = false;
    private bool isBlinking = false;
    private float blinkTimer = 0;
    private float blinkTotalTime = 2.0f;

    void Start()
    {
        charSprites = new SpriteHolder[spriteHolders.transform.childCount];
        for (int i = 0; i < charSprites.Length; i++)
        {
            charSprites[i] = spriteHolders.transform.GetChild(i).GetComponent<SpriteHolder>();
        }
    }

    void Update()
    {
        Sprite spriteToDisplay = gameObject.GetComponent<SpriteRenderer>().sprite;

        if (blinkToggle.isOn)
        {
            blinkTimer += Time.deltaTime;

            if (blinkTimer >= blinkTotalTime-0.1f)
            {
                if (blinkTimer >= blinkTotalTime)
                {
                    blinkTotalTime = Random.Range(1.5f, 2.5f);
                    blinkTimer = 0;
                }
                else
                    isBlinking = true;
            }
            else
                isBlinking = false;
            if (isBlinking)
                spriteToDisplay = (!isTalking) ? charSprites[1].myLoadedSprites[0] : spriteToDisplay = charSprites[3].myLoadedSprites[0];
        }

        if (!isBlinking || !blinkToggle.isOn)
            spriteToDisplay = (!isTalking) ? charSprites[0].myLoadedSprites[0] : spriteToDisplay = charSprites[2].myLoadedSprites[0];

        if (spriteToDisplay != null)
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteToDisplay;
    }

    public void SetTalkingState(bool willBeTalking)
    {
        if (isTalking != willBeTalking)
        {
            isTalking = willBeTalking;
            animator.SetBool("StartedTalking", isTalking);
        }
    }
}