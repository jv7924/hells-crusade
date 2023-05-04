using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    [SerializeField]
    private float maxLifeTime;
    [SerializeField]
    private GameObject respawn;
    
    private Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        float lifetime = velocity.magnitude/ maxLifeTime;
        Destroy(gameObject, maxLifeTime);
    }

    // kill whatever u hit
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerController homie = col.gameObject.GetComponent<PlayerController>();
            if(homie != null){
                homie.takeDamage();
            }
            else{
                Debug.Log(homie);
            } 

        }
        else if(col.gameObject.tag == "Enemy")
        {
            lastPos = col.gameObject.transform.position;
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "Wall"){
            // destroy the spear
            // create collectible spear in its place, 
            // with apropriate offset from the wall 
            lastPos = lastPos = col.gameObject.transform.position;
            Destroy(this.gameObject);
        }
    }

    void OnDestroy(){
        Debug.Log("called");
        if(lastPos == null){
            lastPos = gameObject.transform.position;
        }
        Instantiate(respawn, lastPos, Quaternion.identity);
    }
}
