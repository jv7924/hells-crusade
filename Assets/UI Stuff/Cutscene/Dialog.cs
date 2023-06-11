using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Dialog : MonoBehaviour
{
    public GameObject angel;
    public Sprite noWeapon;
    public Image dialogBox;
    public Sprite[] dialogBoxes;

    public CanvasGroup fadingCanvas;
    //public Animator animator;

    private int spriteNum;
    private bool isFaded = true;

    //public AngelDisAnimation a;


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
            if(spriteNum == 7)
            {
                angel.GetComponent<Image>().sprite = noWeapon;
            }

            dialogBox.sprite = dialogBoxes[spriteNum];
            spriteNum = spriteNum + 1;
        }
    }

    
    public void Fade()
    {
        fadingCanvas.DOFade(0, 1);
        Invoke("Transition", 1);
    }


    private void Transition()
    {
        SceneManager.LoadScene("F1V1");
    }
  
}
