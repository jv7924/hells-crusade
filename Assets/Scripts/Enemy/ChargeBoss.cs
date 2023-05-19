using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBoss : MonoBehaviour
{
    [SerializeField] private int health;
    public float chargeSpeed;
    public float chargeTime;
    private float timeToCharge;
    private GameObject followedPlayer;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 movement;
    private float dist;
    private bool charging = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        timeToCharge = chargeTime;
    }
    /*
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > chargeTime)
        {
            Charge();
        }
    }
    */
    void FixedUpdate()
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

        if (charging == false)
        {
            Vector3 direction = followedPlayer.transform.position - this.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90;
        }

        if (timeToCharge <= 0f)
        {
            Charge();
            timeToCharge = chargeTime;
        } else 
        {
            timeToCharge -= Time.deltaTime;
        }
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * chargeSpeed * Time.deltaTime));
    }

    void Charge()
    {
        charging = true;
        sr.color = Color.red;
        rb.velocity = transform.up * chargeSpeed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Player Hit");
            rb.velocity = Vector3.zero;
            sr.color = Color.white;
            charging = false;
        } else if(col.gameObject.tag == "Wall"){
            Debug.Log("Wall Hit");
            rb.velocity = Vector3.zero;
            sr.color = Color.white;
            charging = false;
        }
        if(col.gameObject.tag == "Spear"){
            health--;
            if(health == 0){
                Destroy(gameObject);
            }
        }
    }
}
