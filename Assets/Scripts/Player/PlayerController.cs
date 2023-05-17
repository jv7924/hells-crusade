using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator playerAnimator;

    [SerializeField]
    int PlayerNumber;

    [SerializeField]
    PlayerMovement movement;
    [SerializeField]
    SpearThrow spearThrow;

    // Start is called before the first frame update
    void Start()
    {
        // someone figure out how to initialize player number correctly lol
        GameManager.Instance.RefreshPlayers.AddListener(Refresh);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void takeDamage()
    {
        Down();
    }

    public void Die()
    {
        // playerAnimator death animation, then
        Destroy(gameObject);
    }

    public void Refresh(){
        movement.enabled = true;
    }

    private void Down()
    {
        GameManager.Instance.downPlayer(PlayerNumber);
        // play down animation
        // restrict movement
        movement.enabled = false;
        Debug.Log("Hit");
    }

    public int GetPlayerNumber()
    {
        return PlayerNumber;
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Pickup"){
            spearThrow.canThrow = true;
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "Enemy"){
            takeDamage();
        }
    }   
}
