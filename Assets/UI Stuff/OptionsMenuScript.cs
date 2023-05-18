using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject overlay;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        overlay.SetActive(false);
    }

    public void OpenOptions()
    {
        menu.SetActive(true);
        overlay.SetActive(true);
    }
    
}
