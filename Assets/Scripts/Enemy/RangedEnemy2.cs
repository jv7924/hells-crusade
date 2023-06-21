using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RangedEnemy2 : Enemy
{
    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;
    public Transform firingPoint;
    public GameObject proj;
    public float fireRate;
    public float enemyForce;
    private float timeToFire;

    public float nextWaypointDistance = 3f;
    private GameObject target;
    private SpriteRenderer sr;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;

    new void Start()
    {
        base.Start();
        seeker = GetComponent<Seeker>();
        sr = GetComponent<SpriteRenderer>();
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void FixedUpdate()
    {
        if (health > 0 && target != null)
        {
            if (path == null)
            {
                return;
            }

            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            } else 
            {
                reachedEndOfPath = false;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector3 direction2 = target.transform.position - this.transform.position;
            Vector2 force = direction * speed * Time.deltaTime;
            direction2.Normalize();
            float angle = Mathf.Atan2(direction2.y, direction2.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90;

            if (Vector2.Distance(target.transform.position, this.transform.position) >= distanceToStop)
            {
                rb.AddForce(force);
            }

            if (Vector2.Distance(target.transform.position, this.transform.position) <= distanceToShoot)
            {
                Shoot();
            }

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }
        Animate();
    }

    private void Shoot()
    {
        if (timeToFire <= 0f)
        {
            GameObject enemySpearInstance = Instantiate(proj, firingPoint.position, firingPoint.rotation);
            Rigidbody2D enemySpearRB = enemySpearInstance.GetComponent<Rigidbody2D>();
            enemySpearRB.AddForce(firingPoint.up * enemyForce, ForceMode2D.Impulse);
            timeToFire = fireRate;

            AudioManager.Instance.Play("SpearThrow");
        } else 
        {
            timeToFire -= Time.deltaTime;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            target = null;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            dist = 99999;
            foreach (GameObject player in players)
            {
                if (player.GetComponent<PlayerController>().PlayerHealth > 0)
                {
                    if (Vector3.Distance(player.transform.position, this.transform.position) < dist)
                    {
                        dist = Vector3.Distance(player.transform.position, this.transform.position);
                        target = player;
                    }
                }
            }
            if (target != null)
            {
                seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
            }
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void Animate()
    {
        animator.SetBool("Attack", (timeToFire <= 0.2f));
        animator.SetInteger("Health", health);
    }
}
