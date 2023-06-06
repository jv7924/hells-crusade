using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour
{
    public GameObject Point;
    private EventSystem m_EventSystem;

    public GameObject playButton;
    public GameObject optionsButton;
    public GameObject exitButton;

    public Transform ButtonPosition1;
    public Transform ButtonPosition2;
    public Transform ButtonPosition3;

    // Gets the EventSystem
    void OnEnable()
    {
        m_EventSystem = EventSystem.current;
    }

    void Update()
    {
        MoveThePointer();
    }

    private void MoveThePointer()
    {
        if (m_EventSystem.currentSelectedGameObject == playButton)
        {
            Point.transform.position = ButtonPosition1.position;
        }
        else if (m_EventSystem.currentSelectedGameObject == optionsButton)
        {
            Point.transform.position = ButtonPosition2.position;
        }
        else if (m_EventSystem.currentSelectedGameObject == exitButton)
        {
            Point.transform.position = ButtonPosition3.position;
        }
    }
    
}
