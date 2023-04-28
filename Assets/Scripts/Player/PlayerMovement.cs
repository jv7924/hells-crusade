using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 0;
    private Rigidbody2D playerRB;
    private Vector2 inputVector;
    public int playerNum = 1;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        inputVector = InputManager.Instance.GetInputVector();

        Move();
    }

    private void Move() 
    {
        playerRB.velocity = inputVector * playerSpeed;
    }
}