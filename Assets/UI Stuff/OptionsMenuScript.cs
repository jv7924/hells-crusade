using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject overlay;
    public GameObject backButton;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        overlay.SetActive(false);
        backButton.SetActive(false);
    }

    public void OpenOptions()
    {
        menu.SetActive(true);
        overlay.SetActive(true);
        backButton.SetActive(true);
    }

    public void CloseOptions()
    {
        menu.SetActive(false);
        overlay.SetActive(false);
        backButton.SetActive(false);
    }
    
}
