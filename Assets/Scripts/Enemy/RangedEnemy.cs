using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public float speed;
    private GameObject followedPlayer;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float dist;

    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;
    public Transform firingPoint;
    public GameObject proj;
    public float fireRate;
    public float enemyForce;
    private float timeToFire;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        timeToFire = 0f;
    }

    private void FixedUpdate()
    {
        dist = 99999;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (Vector3.Distance(player.transform.position, this.transform.position) < dist)
            {
                dist = Vector3.Distance(player.transform.position, this.transform.position);
                followedPlayer = player;
            }
        }

        Vector3 direction = followedPlayer.transform.position - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90;
        direction.Normalize();
        movement = direction;

        if (Vector2.Distance(followedPlayer.transform.position, this.transform.position) >= distanceToStop)
        {
            moveEnemy(movement);
        }

        if (Vector2.Distance(followedPlayer.transform.position, this.transform.position) <= distanceToShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (timeToFire <= 0f)
        {
            GameObject enemySpearInstance = Instantiate(proj, firingPoint.position, firingPoint.rotation);
            Rigidbody2D enemySpearRB = enemySpearInstance.GetComponent<Rigidbody2D>();
            enemySpearRB.AddForce(firingPoint.up * enemyForce, ForceMode2D.Impulse);
            timeToFire = fireRate;
        } else 
        {
            timeToFire -= Time.deltaTime;
        }
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}