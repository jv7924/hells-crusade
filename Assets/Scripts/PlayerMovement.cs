using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 0;
    private Rigidbody2D playerRB;
    private PlayerInputActions playerInputActions;

    // Start is called before the first frame update
    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();   

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        Debug.Log(playerInputActions.Player.Move.activeControl);
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Debug.Log(context.ReadValue<Vector2>());    
            Vector2 inputVector = context.ReadValue<Vector2>();
            playerRB.velocity = inputVector * playerSpeed;
        }
        else 
        {
            playerRB.velocity = Vector2.zero;
        }

    }

    // private void FixedUpdate()
    // {
    //     Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
    //     playerRB.velocity = inputVector * playerSpeed;
    // }
}