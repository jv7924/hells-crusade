using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 0;
    private Rigidbody2D playerRB;
    private Vector2 inputVector;
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void SetUpInputVector(float x, float y)
    {
        inputVector = new Vector2(x, y);
    }

    private void Move() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        SetUpInputVector(horizontalInput, verticalInput);

        playerRB.velocity = inputVector * playerSpeed;
    }
}