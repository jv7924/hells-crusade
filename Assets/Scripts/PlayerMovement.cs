using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 0;
    private Rigidbody2D playerRB;
    private Vector2 inputVector;
    public int playerNum = 1;
    InputManager manager;

    // Temp
    

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<InputManager>();
    }

    private void FixedUpdate()
    {
        inputVector = manager.GetInputVector();

        Move();
    }

    private void Move() 
    {
        playerRB.velocity = inputVector * playerSpeed;
    }
}