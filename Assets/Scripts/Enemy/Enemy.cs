using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    protected GameObject followedPlayer;
    protected Rigidbody2D rb;
    protected Vector2 movement;
    protected float dist = 99999;
    protected Animator animator;
    protected GameObject[] players;

    [SerializeField]
    protected int health = 1;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        players = GameObject.FindGameObjectsWithTag("Player");
        animator.SetInteger("Health", health);
    }

    public void DamageEnemy()
    {
        health--;
        if (health <= 0)
        {
            transform.rotation = Quaternion.identity;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Collider2D>().enabled = false;
            foreach (Transform child in GetComponentInChildren<Transform>())
            {
                child.gameObject.SetActive(false);
            }
            //Debug.Log("Destroying enemy.");
            Destroy(gameObject, 1f);
        }
    }

    void OnDestroy(){
        Debug.Log("Enemy Killed");
        FloorManager.Instance.OnEnemyDeath.Invoke();
    }
}
