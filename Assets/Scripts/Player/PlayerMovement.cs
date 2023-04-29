using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 0;
    private Rigidbody2D playerRB;
    private Vector2 inputVector;
    private InputManager input;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        input = GetComponent<InputManager>();
    }

    private void FixedUpdate()
    {
        inputVector = input.GetInputVector();

        Move();
    }

    private void Move() 
    {
        playerRB.velocity = inputVector * playerSpeed;
    }
}