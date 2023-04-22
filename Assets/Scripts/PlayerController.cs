using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    bool canShoot;
    [SerializeField]
    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        // if the other player is already downed, just die - we will need a gamemanager that keeps track of player life
        if (false)
        {
            Die();
        }
        else
        {
            // down the player for revival
        }
    }

    private void Die()
    {
        // playerAnimator death animation, then
        Destroy(gameObject);
    }
}
