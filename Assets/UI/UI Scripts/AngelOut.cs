using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelOut : MonoBehaviour
{
    public GameObject angel;
    public AngelDisAnimation a;

    private bool smoked = false;
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

    public void DelAngel()
    {
        angel.SetActive(false);
    }
}
