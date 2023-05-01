using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    private Vector2 inputVector;
    private float horizontalInput;
    private float verticalInput;
    private int playerNum;

    // Temp
    enum GameMode
    {
        ONLINE,
        LOCAL
    }
    // Temp
    private GameMode mode;

    private void Start()
    {
        mode = GameMode.ONLINE;  // Temp
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
        if (mode == GameMode.ONLINE)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }
        else if (mode == GameMode.LOCAL)
        {
            // Get the players number so that the controls can be set up easy
            horizontalInput = Input.GetAxisRaw("Horizontal Local " + player);
            verticalInput = Input.GetAxisRaw("Vertical Local " + player);
        }

        return new Vector2(horizontalInput, verticalInput);
    }
}
