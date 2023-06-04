using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject Point;

    private int SelectedButton = 1;
    [SerializeField]
    private int NumberOfButtons;

    public Transform ButtonPosition1;
    public Transform ButtonPosition2;


    private void OnPlay()
    {
        if (SelectedButton == 1)
        {
            // If Play Button selected, load game
            SceneManager.LoadScene(2);
        }
        else if (SelectedButton == 2)
        {
            // If Exit Button selected, exit game
            Application.Quit();
        }
    }

    private void OnButtonLeft()
    {
        // Checks if the pointer needs to move left or right, in this case the poiter moves left one button
        if (SelectedButton > 1)
        {
            SelectedButton -= 1;
        }
        MovePointer();
        return;
    }

    private void OnButtonRight()
    {
        // Checks if the pointer needs to move left or right, in this case the poiter moves right one button
        if (SelectedButton < NumberOfButtons)
        {
            SelectedButton += 1;
        }
        MovePointer();
        return;
    }

    private void MovePointer()
    {
        // Moves the pointer
        if (SelectedButton == 1)
        {
            Point.transform.position = ButtonPosition1.position;
        }
        else if (SelectedButton == 2)
        {
            Point.transform.position = ButtonPosition2.position;
        }
    }

}
