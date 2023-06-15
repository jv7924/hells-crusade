using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyFollow2 : Enemy
{
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
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void FixedUpdate()
    {
        Animate();

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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector2 force = direction * speed * Time.deltaTime;
        movement = direction;

        rb.AddForce(force);
        if (angle > 90 || angle < -90)
        {
            sr.flipX = true;
        } else 
        {
            sr.flipX = false;
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            dist = 99999;
            foreach (GameObject player in players)
            {
                if (Vector3.Distance(player.transform.position, this.transform.position) < dist)
                {
                    dist = Vector3.Distance(player.transform.position, this.transform.position);
                    target = player;
                }
            }
            seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
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
        animator.SetFloat("Distance To Player", dist);
        animator.SetFloat("Speed", movement.magnitude * speed);
        animator.SetInteger("Health", health);
    }
}
