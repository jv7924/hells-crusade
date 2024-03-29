using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject overlay;
    public GameObject backButton;
    public GameObject exitButton;
    private bool isOpen;

    public Image ResolutionImage;
    public Sprite[] resSprites;
    private int defaultRes;


    // Hides options menu ui
    void Start()
    {
        menu.SetActive(false);
        overlay.SetActive(false);
        exitButton.SetActive(false);
        isOpen = false;
        defaultRes = 1;

        if(backButton != null)
        {
            backButton.SetActive(false);
        }
    }

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
        exitButton.SetActive(true);
        isOpen = true;

        if (backButton != null)
        {
            backButton.SetActive(true);
        }
    }

    public void CloseOptions()
    {
        menu.SetActive(false);
        overlay.SetActive(false);
        exitButton.SetActive(false);
        isOpen = false;
        Time.timeScale = 1f;

        if (backButton != null)
        {
            backButton.SetActive(false);
        }
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    
    public void SwapResolutionLeft()
    {
        if(defaultRes > 0)
        {
            defaultRes -= 1;
        }

        else if(defaultRes == 0)
        {
            defaultRes = 2;
        }

        ResolutionImage.sprite = resSprites[defaultRes];
        ChangeResolution();

    }
    
    public void SwapResolutionRight()
    {
        if (defaultRes < 2)
        {
            defaultRes += 1;
        }

        else if (defaultRes == 2)
        {
            defaultRes = 0;
        }

        ResolutionImage.sprite = resSprites[defaultRes];
        ChangeResolution();

    }

    private void ChangeResolution()
    {
        if(defaultRes == 0)
        {
            Screen.SetResolution(1280, 720, Screen.fullScreen);
        }
        
        else if(defaultRes == 1)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
        }
        
        else if(defaultRes == 2)
        {
            Screen.SetResolution(2560, 1440, Screen.fullScreen);
        }
    }

}
