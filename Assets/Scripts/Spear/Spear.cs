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
    private bool debugging;
    // Start is called before the first frame update
    void Start()
    {
        debugging = GameManager.Instance.debugMode;
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
        if(col.gameObject.tag == "Enemy")
        {
            enemyHit = true;
            GameManager.Instance.EnemyHit.Invoke(playerNumber);
            // Destroy(col.gameObject) -> no longer need
            Destroy(gameObject);
            
        }
        else if(col.gameObject.tag == "Wall"){
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "Boss"){
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
