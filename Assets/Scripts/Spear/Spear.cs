using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    [SerializeField]
    private float maxLifeTime;
    [SerializeField]
    private GameObject respawn;
    [SerializeField]
    private int playerNumber;
    
    private Vector3 lastPos;
    private bool enemyHit;
    // Start is called before the first frame update
    void Start()
    {
        // need better formula for max lifetime
        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        float lifetime = velocity.magnitude/ maxLifeTime;
        enemyHit = false;
        Destroy(gameObject, maxLifeTime);
    }

    private void FixedUpdate()
    {
        lastPos = transform.position;
    }

    // detect hitting something
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Freindly Fire");
            
        }
        else if(col.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Hit");
            enemyHit = true;
            GameManager.Instance.EnemyHit.Invoke(playerNumber);
            col.gameObject.GetComponent<Enemy>().DamageEnemy();
            //Destroy(col.gameObject);
            Destroy(gameObject);
            
        }
        else if(col.gameObject.tag == "Wall"){
            Debug.Log("Wall Hit");
            
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "Boss"){
            Debug.Log("Boss Hit");
            enemyHit = true;
            GameManager.Instance.EnemyHit.Invoke(playerNumber);
            Destroy(this.gameObject);
        }
    }

    void OnDestroy(){
        if (!enemyHit)
        {
            Instantiate(respawn, lastPos, Quaternion.identity);
        }
    }

    private Vector3 findOffset(Vector3 colPos)
    {
        return transform.position;
    }
}
