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
    }

    public void DamageEnemy()
    {
        health--;
        //Debug.Log("HEALTH = " + health);
        if (health <= 0)
        {
            //Debug.Log("Destroying enemy.");
            Destroy(gameObject);
        }
    }
}
