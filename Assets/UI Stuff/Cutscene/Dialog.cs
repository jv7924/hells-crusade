using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Dialog : MonoBehaviour
{
    public Image dialogBox;
    public Sprite[] dialogBoxes;

    public CanvasGroup fadingCanvas;

    private int spriteNum;
    private bool isFaded = true;


    // Start is called before the first frame update
    void Start()
    {
        spriteNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFaded)
        {
            fadingCanvas.DOFade(1, 2);
        }

        isFaded = false;
    }

    public void ChangeBox()
    {
        Sprite nSprite = dialogBoxes[spriteNum];
        Debug.Log(dialogBoxes[spriteNum]);
        dialogBox.sprite = nSprite;
        spriteNum = spriteNum + 1;
    }

    public void Fader()
    {
        isFaded = !isFaded;

        if(isFaded)
        {
            fadingCanvas.DOFade(1, 2);
        }
        else
        {
            fadingCanvas.DOFade(0, 2);
        }
    }
}
