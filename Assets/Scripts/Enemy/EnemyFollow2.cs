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
        sr = GetComponent<SpriteRenderer>();
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void FixedUpdate()
    {
        if (health > 0)
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
            movement = direction;

            rb.AddForce(force);

            if (force.x >= 0.01f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            } else if (force.x <= -0.01f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }
        Animate();
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
