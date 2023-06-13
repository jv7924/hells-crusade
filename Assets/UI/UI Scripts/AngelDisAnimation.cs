using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AngelDisAnimation : MonoBehaviour
{
    public GameObject angel;
    public Sprite angelSprite;
    public Sprite[] sprites;
    public GameObject deathOverlay;
    public GameObject deathButtons;
    public CanvasGroup fadingCanvas;

    private GameObject player1;
    private GameObject player2;

    private int spriteIndex;
    private bool appeared = false;

    // Start is called before the first frame update
    void Start()
    {
        if(deathOverlay != null)
        {
            deathOverlay.SetActive(false);
            deathButtons.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(deathOverlay != null)
        {
            if (deathOverlay.activeInHierarchy && appeared == false)
            {
                player1 = GameObject.Find("Player 1(Clone)");
                player2 = GameObject.Find("Player 2(Clone)");

                player1.GetComponent<SpearThrow>().canThrow = false;
                player2.GetComponent<SpearThrow>().canThrow = false;

                deathButtons.SetActive(true);
                appeared = true;
                Invoke("SmokeIn", 0.4f);
                Invoke("FadeButtonsIn", 0.7f);
            }

        }   
    }

    private void FadeButtonsIn()
    {
        fadingCanvas.DOFade(1, 1);
    }

    private void SmokeIn()
    {
        angel.SetActive(true);
        StartCoroutine(doOtherAnimation());
    }

    public void smoke()
    {
        Debug.Log("Smoke!");
        StartCoroutine(doAnimation());
    }

    IEnumerator doAnimation()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            yield return new WaitForSeconds(0.1F);
            angel.GetComponent<Image>().sprite = sprites[i];
        }
    }

    IEnumerator doOtherAnimation()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            yield return new WaitForSeconds(0.05F);
            angel.GetComponent<Image>().sprite = sprites[i];
        }

        angel.GetComponent<Image>().sprite = angelSprite;
    }
}
