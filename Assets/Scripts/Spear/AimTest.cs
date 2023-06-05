using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTest : MonoBehaviour
{
    [SerializeField]
    public GameObject crosshair;
    [SerializeField]
    private Camera mainCam;
    [SerializeField]
    private PlayerController playerCon;
    [SerializeField]
    private Transform playerCenter;
    [SerializeField]
    private float playerTwoSens = 0;
    private int playerNum;
    private float horizontalInput;
    private float verticalInput;


    // Start is called before the first frame update
    void Start()
    {
        playerNum = playerCon.GetPlayerNumber();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        CheckBounds();
    }

    private void CheckBounds()
    {
        Vector2 offset = (Vector2)crosshair.transform.position - (Vector2)playerCenter.transform.position;
        transform.position = (Vector2)playerCenter.transform.position + Vector2.ClampMagnitude(offset, 4);
    }

    private void Aim()
    {
        if (playerNum == 2)
        {
            horizontalInput = Input.GetAxisRaw("Aim Horizontal");
            verticalInput = Input.GetAxisRaw("Aim Vertical");

            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);

            crosshair.transform.position += (Vector3)inputVector * Time.deltaTime * playerTwoSens;
        }

        else if (playerNum == 1)
            crosshair.transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);

        // horizontalInput = Input.GetAxisRaw("Aim Horizontal " + playerNum);
        // verticalInput = Input.GetAxisRaw("Aim Vertical " + playerNum);

        // Vector2 inputVector = new Vector2(horizontalInput, verticalInput);

        // crosshair.transform.position += (Vector3)inputVector * Time.deltaTime * playerTwoSens;
    }

    public Vector3 MousePos()
    {
        return crosshair.transform.position;
    }
}
