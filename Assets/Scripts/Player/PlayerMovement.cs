using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 0;
    private Rigidbody2D playerRB;
    private Vector2 inputVector;
    private InputManager input;
    private Animator animator;
    private SpriteRenderer sr;

    public InputAction playerControls;

    private bool isWalking;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        playerControls.Enable();
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        input = GetComponent<InputManager>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // if (GameModeManager.gameMode == GameModeManager.GameMode.ONLINE && view.IsMine)
        // {
        //     mousePos = GameManager.Instance.cursorPos();
        // }
        // else if (GameModeManager.gameMode == GameModeManager.GameMode.LOCAL)
        // {
        //     mousePos = GameManager.Instance.cursorPos();
        // }
        // inputVector = input.GetInputVector();
        inputVector = playerControls.ReadValue<Vector2>();
    }


    void FixedUpdate()
    {
        Move();
    }

    private void Move() 
    {
        // playerRB.MovePosition(playerRB.position + inputVector * playerSpeed * Time.fixedDeltaTime);
        playerRB.velocity = inputVector * playerSpeed;
        SetAnimation();
    }

    private void SetAnimation()
    {
        animator.SetFloat("Velocity", playerRB.velocity.magnitude);
        if (playerControls.ReadValue<Vector2>().x < 0)
        {
            sr.flipX = true;
        }
        else if (playerControls.ReadValue<Vector2>().x > 0)
        {
            sr.flipX = false;
        }
    }
}