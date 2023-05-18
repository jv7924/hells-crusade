using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject overlay;
    public GameObject backButton;
    private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        overlay.SetActive(false);
        backButton.SetActive(false);
        isOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isOpen == true)
            {
                Debug.Log("Pressed");
                CloseOptions();
            }

            else
            {
                OpenOptions();
            }
        }
    }

    public void OpenOptions()
    {
        menu.SetActive(true);
        overlay.SetActive(true);
        backButton.SetActive(true);
        isOpen = true;
    }

    public void CloseOptions()
    {
        menu.SetActive(false);
        overlay.SetActive(false);
        backButton.SetActive(false);
        isOpen = false;
    }
    
}
