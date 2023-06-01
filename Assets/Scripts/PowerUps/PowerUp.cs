using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    protected GameObject player;
    protected GameObject spear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void PowerUpAction() { throw new System.NotImplementedException("Base"); }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other.gameObject;
        // spear = player.GetComponent<SpearThrow>().GetSpear();
        // Call the powerup method
        PowerUpAction();
        PowerUpDestroy();
    }

    protected virtual void PowerUpDestroy() 
    { 
        Destroy(gameObject);
    }
}
