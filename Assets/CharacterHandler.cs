using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    [HideInInspector]
    public bool isTalking = false;

    public SpriteHolder closedMouth;
    public SpriteHolder openMouth;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Sprite spriteToDisplay = gameObject.GetComponent<SpriteRenderer>().sprite;

        if (!isTalking)
        {
            spriteToDisplay = closedMouth.myLoadedSprites[0];
        }
        else
        {
            spriteToDisplay = openMouth.myLoadedSprites[0];
        }

        if (spriteToDisplay != null)
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteToDisplay;
    }

    public void SetTalkingState(bool willBeTalking)
    {
        if (isTalking != willBeTalking)
        {
            isTalking = willBeTalking;
            animator.SetBool("Talking", isTalking);
        }
    }
}