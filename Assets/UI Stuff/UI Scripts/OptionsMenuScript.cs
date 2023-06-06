using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    private EventSystem m_EventSystem;

    public GameObject menu;
    public GameObject overlay;
    public GameObject backButton;
    public GameObject exitButton;
    public GameObject ogButton;
    private bool isOpen;

    public Image ResolutionImage;
    public Sprite[] resSprites;
    private int defaultRes;

    // Gets the EventSystem
    void OnEnable()
    {
        m_EventSystem = EventSystem.current;
    }

    // Hides options menu ui
    void Start()
    {
        menu.SetActive(false);
        overlay.SetActive(false);
        backButton.SetActive(false);
        exitButton.SetActive(false);
        isOpen = false;
        defaultRes = 1;
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
        backButton.SetActive(true);
        exitButton.SetActive(true);
        isOpen = true;

        m_EventSystem.SetSelectedGameObject(backButton);
    }

    public void CloseOptions()
    {
        menu.SetActive(false);
        overlay.SetActive(false);
        backButton.SetActive(false);
        exitButton.SetActive(false);
        isOpen = false;
        Time.timeScale = 1f;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            m_EventSystem.SetSelectedGameObject(ogButton);
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
