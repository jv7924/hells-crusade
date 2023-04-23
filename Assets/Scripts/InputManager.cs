using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;
    private Vector2 inputVector;
    private float horizontalInput;
    private float verticalInput;

    // Temp
    enum GameMode
    {
        SINGLE,
        COOP
    }
    // Temp
    private GameMode mode;

    private void Start()
    {
        // Temp
        mode = GameMode.SINGLE;
    }

    private void Update()
    {
        SetUpInputVector(SetUpAxis());
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
    public Vector2 SetUpAxis()
    {
        if (mode == GameMode.SINGLE)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }
        else if (mode == GameMode.COOP)
        {
            // Get the players number so that the controls can be set up easy
            // horizontalInput = Input.GetAxisRaw("Horizontal Local " +);
            // verticalInput = Input.GetAxisRaw("Vertical Local " +);
        }

        return new Vector2(horizontalInput, verticalInput);
    }
}
