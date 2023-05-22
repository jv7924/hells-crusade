using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpeedUp : PowerUp
{
    protected override void PowerUpAction(GameObject player)
    {
        player.GetComponent<SpearThrow>().maxChargeTime -= player.GetComponent<SpearThrow>().maxChargeTime *.50f;
    }
}
