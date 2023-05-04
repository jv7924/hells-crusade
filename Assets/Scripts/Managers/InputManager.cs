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
    private int playerNum;

    private void Start()
    {
        playerNum = GetComponent<PlayerController>().GetPlayerNumber();
    }

    private void Update()
    {
        SetUpInputVector(SetUpAxis(playerNum));
    }

    private void SetUpInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    public Vector2 GetInputVector()
    {
        return inputVector;
    }

    // Temp
    private Vector2 SetUpAxis(int player)
    {
        if (GameModeManager.gameMode == GameModeManager.GameMode.ONLINE)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }
        else if (GameModeManager.gameMode == GameModeManager.GameMode.LOCAL)
        {
            // Get the players number so that the controls can be set up easy
            horizontalInput = Input.GetAxisRaw("Horizontal Local " + player);
            verticalInput = Input.GetAxisRaw("Vertical Local " + player);
        }

        return new Vector2(horizontalInput, verticalInput);
    }
}
