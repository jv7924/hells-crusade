using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] private float speed = 10f;
    [Range(1,10)]
    [SerializeField] private float lifeTime = 3f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit");
            Destroy(gameObject);
        } else if(col.gameObject.tag == "Wall"){
            Debug.Log("Wall Hit");
            Destroy(gameObject);
        }
    }
}
