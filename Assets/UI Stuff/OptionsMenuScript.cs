using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject overlay;
    public GameObject backButton;
    public GameObject exitButton;
    private bool isOpen;
    
    // Hides options menu ui
    void Start()
    {
        menu.SetActive(false);
        overlay.SetActive(false);
        backButton.SetActive(false);
        exitButton.SetActive(false);
        isOpen = false;
    }

    // If esc key is pressed, reveal or hide ui
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isOpen == true)
            {
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
        Time.timeScale = 0f;
        menu.SetActive(true);
        overlay.SetActive(true);
        backButton.SetActive(true);
        exitButton.SetActive(true);
        isOpen = true;
    }

    public void CloseOptions()
    {
        menu.SetActive(false);
        overlay.SetActive(false);
        backButton.SetActive(false);
        exitButton.SetActive(false);
        isOpen = false;
        Time.timeScale = 1f;
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
