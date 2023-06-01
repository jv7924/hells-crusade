using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : PowerUp
{
    protected override void PowerUpAction()
    {
        player.GetComponent<PlayerMovement>().playerSpeed += player.GetComponent<PlayerMovement>().playerSpeed * .15f;
    }
}
