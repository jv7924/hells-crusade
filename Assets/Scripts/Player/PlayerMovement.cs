using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 0;
    private Rigidbody2D playerRB;
    private Vector2 inputVector;
    private InputManager input;
    private Vector2 mousePos;
    private PhotonView view;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        input = GetComponent<InputManager>();
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (GameModeManager.gameMode == GameModeManager.GameMode.ONLINE && view.IsMine)
        {
            mousePos = GameManager.Instance.cursorPos();
        }
        else if (GameModeManager.gameMode == GameModeManager.GameMode.LOCAL)
        {
            mousePos = GameManager.Instance.cursorPos();
        }
        inputVector = input.GetInputVector();
    }


    void FixedUpdate()
    {
        if (GameModeManager.gameMode == GameModeManager.GameMode.ONLINE && view.IsMine)
        {
            Move();
            Rotate();
        }
        else if (GameModeManager.gameMode == GameModeManager.GameMode.LOCAL)
        {
            Move();
            Rotate();
        }
    }

    private void Move() 
    {
        // playerRB.MovePosition(playerRB.position + inputVector * playerSpeed * Time.fixedDeltaTime);
        playerRB.velocity = inputVector * playerSpeed;
    }

    private void Rotate()
    {
        Vector2 aimDirection = mousePos - playerRB.position;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        // playerRB.rotation = angle;
    }
}