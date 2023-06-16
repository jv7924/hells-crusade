using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;

    private Collider2D col;

    [SerializeField]
    int PlayerNumber;

    [SerializeField]
    PlayerMovement movement;
    [SerializeField]
    SpearThrow spearThrow;

    [SerializeField]
    public float PlayerHealth { get; private set; } = 1;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.EnemyHit.AddListener(checkRefresh);
        GameManager.Instance.RefreshPlayers.AddListener(Refresh);
        col = GetComponent<Collider2D>();
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
        // NOTE: Commented these out bc I wanted the player objects
        // + their location to stay in game over transition

        // playerAnimator death animation
        // gameObject.SetActive(false);
    }

    public void Refresh(){
        PlayerHealth = 1;
        col.enabled = true;
        movement.enabled = true;
        spearThrow.canThrow = true;
        playerAnimator.SetBool("Downed", false);
        Debug.Log("player revived");
    }


    private void Down()
    {
        GameManager.Instance.downPlayer(PlayerNumber);
        PlayerHealth = 0;
        col.enabled = false;
        Debug.Log("player downed");
        playerAnimator.SetBool("Downed", true);
        // play down animation - still need

        // restrict movement
        movement.enabled = false;
        movement.freeze();

        // restrict throwing
        spearThrow.canThrow = false;
    }

    public int GetPlayerNumber()
    {
        return PlayerNumber;
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Pickup")){
            if (spearThrow.canThrow == false)
            {
                AudioManager.Instance.Play("RechargeSpear");
                spearThrow.canThrow = true;
                Destroy(col.gameObject);
            }
        }
        if(col.gameObject.CompareTag("Enemy")){
            AudioManager.Instance.Play("EnemySplat");
            takeDamage();
        }
        if(col.gameObject.CompareTag("Boss")){
            AudioManager.Instance.Play("EnemySplat");
            takeDamage();
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Bullet")){
            AudioManager.Instance.Play("EnemySplat");
            takeDamage();
        }
        //else if(col.gameObject.CompareTag("Spear")){
        //    if(col.gameObject != spearThrow.GetSpear()){
        //        takeDamage();
        //    }
        //}
    }   

    private void checkRefresh(int playerNumber)
    {
        if(playerNumber == PlayerNumber)
        {
            Refresh();
        }
    }
}
