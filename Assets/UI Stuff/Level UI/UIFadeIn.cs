using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIFadeIn : MonoBehaviour
{
    public CanvasGroup fadingCanvas;
    private bool isFaded = true;

    void Start()
    {
        if (isFaded)
        {
            fadingCanvas.DOFade(1, 0.7f);
        }

        isFaded = false;

    }
}
