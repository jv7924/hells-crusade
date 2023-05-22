using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoReturnSpear : PowerUp
{
    private bool isAbleToThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("In spear return update");

        Debug.Log(isAbleToThrow);

        if (isAbleToThrow == false)
            isAbleToThrow = true;
    }

    protected override void PowerUpAction(GameObject player)
    {
        isAbleToThrow = player.GetComponent<SpearThrow>().canThrow;
        Debug.Log("In overrident powerup spear return");
    }

    protected override void PowerUpDestroy()
    {
        gameObject.GetComponent<SpriteRenderer>().forceRenderingOff = true;
    }
}
