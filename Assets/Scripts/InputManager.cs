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

    enum GameMode
    {
        SINGLE,
        COOP
    }

    private GameMode mode;

    private void Start()
    {
        // Temp
        mode = GameMode.SINGLE;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        SetUpInputVector(SetUpAxis());
    }

    private void SetUpInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    public Vector2 GetVec()
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
        // else if (mode == GameMode.COOP)
        // {
        //     horizontalInput = Input.GetAxisRaw("Horizontal Local " + );
        //     verticalInput = Input.GetAxisRaw("Vertical Local " + );
        // }

        return new Vector2(horizontalInput, verticalInput);
    }
}
