using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngelDisAnimation : MonoBehaviour
{
    public GameObject angel;
    public Sprite angelSprite;
    public Sprite[] sprites;
    public GameObject deathOverlay;

    private int spriteIndex;
    private bool appeared = false;

    // Start is called before the first frame update
    void Start()
    {
        deathOverlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(deathOverlay.activeInHierarchy && appeared == false)
        {
            appeared = true;
            Invoke("SmokeIn", 0.4f);
        }
        
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
            yield return new WaitForSeconds(0.3F);
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
