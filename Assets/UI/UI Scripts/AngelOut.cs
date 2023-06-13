using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AngelOut : MonoBehaviour
{
    public GameObject angel;
    public AngelDisAnimation a;
    public CanvasGroup fadingCanvas;

    public bool smoked = false;
    // Start is called before the first frame update
    void Start()
    {
        //a.smoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(smoked == false)
        {
            a.smoke();
            Invoke("DelAngel", 0.4f);
            smoked = true;

        }
    }

    public void SmokeAgain()
    {
        a.smoke();
        Invoke("DelAngel", 0.8f);
    }

    public void DelAngel()
    {
        angel.SetActive(false);
        Invoke("Fade", 0.4f);
    }

    private void Fade()
    {
        fadingCanvas.DOFade(1, 2f);
    }
}
