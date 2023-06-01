using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**********************************************************
NOTES:
    - Controller right joystick works with 3rd axis and
     4th axis for the axis type.

    -
    
**********************************************************/

public class InputManager : MonoBehaviour
{
    private Vector2 inputVector;
    private float horizontalInput;
    private float verticalInput;
    private string shootButton;
    private int playerNum;

    private void Awake()
    {
        playerNum = GetComponent<PlayerController>().GetPlayerNumber();
    }

    private void Update()
    {
        SetUpAxis();
        SetUpShooting();
    }

    public Vector2 GetInputVector()
    {
        return inputVector;
    }

    public string GetShootButton()
    {
        return shootButton;
    }

    private void SetUpAxis()
    {
        // Get the players number so that the controls can be set up easy
        horizontalInput = Input.GetAxisRaw("Horizontal Local " + playerNum);
        verticalInput = Input.GetAxisRaw("Vertical Local " + playerNum);

        inputVector = new Vector2(horizontalInput, verticalInput);
    }

    private void SetUpShooting()
    {
        shootButton = "Fire" + playerNum;
    }
}
