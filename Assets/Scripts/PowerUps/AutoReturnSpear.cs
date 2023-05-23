using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoReturnSpear : PowerUp
{
    private bool isAbleToThrow;
    private bool powerUpCollected = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpCollected)
            PowerUpAction();
    }

    protected override void PowerUpAction()
    {
        if (player.GetComponent<SpearThrow>().canThrow == false)
            player.GetComponent<SpearThrow>().canThrow = true;

        powerUpCollected = true;
    }

    protected override void PowerUpDestroy()
    {
        gameObject.transform.SetParent(player.transform);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
