using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TransitionCanvasScript : MonoBehaviour
{ 
    [SerializeField]
    private GameObject tcanvas;

    [SerializeField]
    private CanvasGroup tcanvasgroup;

    [SerializeField]
    private CanvasGroup skyCG;

    [SerializeField]
    private CanvasGroup hud;

    private GameObject player1;
    private GameObject player2;

    void Start()
    {
        //play1tele.SetActive(false);
        //play2tele.SetActive(false);
        //tcanvas.SetActive(false);
    }

    void Update()
    {
        player1 = GameObject.Find("Player 1(Clone)");
        player2 = GameObject.Find("Player 2(Clone)");

        //player1.GetComponent<SpearThrow>().canThrow = false;
        //player2.GetComponent<SpearThrow>().canThrow = false;
    }

    public void BeginTransition()
    {
        hud.DOFade(0, 1);
        tcanvasgroup.DOFade(1, 1);
        Invoke("FadeSkyIn", 1);
    }

    private void FadeSkyIn()
    {
        skyCG.DOFade(1, 1);
        Invoke("SwapScene", 1.3f);
    }

    private void SwapScene()
    {
        SceneManager.LoadScene(6);
    }
}
