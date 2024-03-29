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
    private bool targeted = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
        timeToCharge = chargeTime;
    }

    void FixedUpdate()
    {
        dist = 99999;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (!targeted)
        {
            foreach (GameObject player in players)
            {
                if (Vector3.Distance(player.transform.position, this.transform.position) < dist)
                {
                    dist = Vector3.Distance(player.transform.position, this.transform.position);
                    followedPlayer = player;
                    targeted = true;
                }
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
        AudioManager.Instance.Play("BossCharge");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Spear")){
            health--;
            if(health == 0){
                Destroy(gameObject);
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            rb.velocity = Vector3.zero;
            sr.color = Color.white;
            charging = false;
            targeted = false;
        } 
        if(col.gameObject.CompareTag("Wall"))
        {
            AudioManager.Instance.Play("BossChargeEnd");
            Debug.Log("Wall Hit");
            rb.velocity = Vector3.zero;
            sr.color = Color.white;
            charging = false;
            targeted = false;
        }
        if(col.gameObject.CompareTag("Spear")){
            health--;
            if(health == 0){
                Destroy(gameObject);
            }
        }
    }

    void OnDestroy(){
        Debug.Log("Boss Killed");
        AudioManager.Instance.Play("BossDeath");
        FloorManager.Instance.OnEnemyDeath.Invoke();
    }
}
