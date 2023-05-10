using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTest : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public Rigidbody2D obj;
    public GameObject gameObj;
    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // horizontalInput = Input.GetAxisRaw("Aim Horizontal");
        // verticalInput = Input.GetAxisRaw("Aim Vertical");

        // Vector2 inputVector = new Vector2(horizontalInput, verticalInput);

        // obj.velocity = inputVector * 3;

        obj.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
