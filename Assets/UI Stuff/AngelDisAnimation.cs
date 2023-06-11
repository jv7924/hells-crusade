using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngelDisAnimation : MonoBehaviour
{
    public Image angel;
    public Sprite[] sprites;
    public float speed;

    private int spriteIndex;
    Coroutine coroAnim;
    //private bool isDone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            yield return new WaitForSeconds(0.03F);
            angel.sprite = sprites[i];
        }
    }
}
