using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    [SerializeField]
    private float maxLifeTime;
    // Start is called before the first frame update
    void Start()
    {
        // spears will be instantiated by spear throw with a lifetime calculated
        // based on how long the throw is charged up
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
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "Wall"){
            // destroy the spear
            // create collectible spear in its place, 
            // with apropriate offset from the wall
        }
    }
}
