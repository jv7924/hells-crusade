using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Dialog : MonoBehaviour
{
    public GameObject angel;
    public Image dialogBox;
    public Sprite[] dialogBoxes;

    public CanvasGroup fadingCanvas;
    public Animator animator;

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
        if (spriteNum >= dialogBoxes.Length)
        {
            Fade();
        }
        else
        {
            //Sprite nSprite = dialogBoxes[spriteNum];
            dialogBox.sprite = dialogBoxes[spriteNum];
            spriteNum = spriteNum + 1;
        }
    }

    public void Fader()
    {

        if(isFaded)
        {
            fadingCanvas.DOFade(1, 2);
        }
        else
        {
            fadingCanvas.DOFade(0, 2);
        }
    }

    private void Fade()
    {
        fadingCanvas.DOFade(0, 2);
        Invoke("Transition", 2);
    }

    public void Transition()
    {
        angel.SetActive(false);
        SceneManager.LoadScene("F1V1");
    }
}
