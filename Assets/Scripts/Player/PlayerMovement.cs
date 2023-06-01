using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 0;
    private Rigidbody2D playerRB;
    private Vector2 inputVector;
    private InputManager input;
    private Vector2 mousePos;
    private PhotonView view;
    private Animator animator;
    private SpriteRenderer sr;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        input = GetComponent<InputManager>();
        view = GetComponent<PhotonView>();
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
        inputVector = input.GetInputVector();
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
        if (input.GetInputVector().x < 0)
        {
            sr.flipX = true;
        }
        else if (input.GetInputVector().x > 0)
        {
            sr.flipX = false;
        }
    }
}