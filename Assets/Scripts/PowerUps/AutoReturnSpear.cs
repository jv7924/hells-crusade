using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoReturnSpear : PowerUp
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void PowerUpAction(GameObject player)
    {
        player.GetComponent<PlayerMovement>().playerSpeed = 9;
    }
}
