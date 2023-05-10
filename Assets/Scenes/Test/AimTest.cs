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
    public PlayerController con;
    private bool outOfBounds = false;
    public Transform center;
    int num;

    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<Rigidbody2D>();
        num = con.GetPlayerNumber();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();

        if (!outOfBounds)
            Aim();
    }
    

    private void CheckBounds()
    {
        Vector2 offset = obj.position - (Vector2)center.transform.position;
        transform.position = (Vector2)center.transform.position + Vector2.ClampMagnitude(offset, 4);
    }

    private void Aim()
    {
        if (num == 2)
        {
            horizontalInput = Input.GetAxisRaw("Aim Horizontal");
            verticalInput = Input.GetAxisRaw("Aim Vertical");

            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);

            obj.velocity = inputVector * 50;
        }

        else if (num == 1)
            obj.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
