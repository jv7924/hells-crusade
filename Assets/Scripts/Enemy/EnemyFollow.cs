using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : Enemy
{
    private SpriteRenderer sr;

    new void Start()
    {
        base.Start();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        /*
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        moveEnemy(movement);
        */

        dist = 99999;
        //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
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
        if (angle > 90 || angle < -90)
        {
            sr.flipX = true;
        } else 
        {
            sr.flipX = false;
        }
        direction.Normalize();
        movement = direction;
        moveEnemy(movement);

        Animate();
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void Animate()
    {
        animator.SetFloat("Distance To Player", dist);
        animator.SetFloat("Speed", movement.magnitude * speed);
    }
}
