using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 0;
    private Rigidbody2D playerRB;
    private Vector2 inputVector;
    // [SerializeField] private int playerNum = 1;
    InputManager manager;

    // Temp
    

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<InputManager>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    

    private void FixedUpdate()
    {
        inputVector = manager.GetVec();

        Move();
    }

    

    private void Move() 
    {
        playerRB.velocity = inputVector * playerSpeed;
    }
}