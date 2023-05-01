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
    private void OnCollision(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerController homie = other.GetComponent<PlayerController>();
            if(homie != null){
                homie.takeDamage();
            }
            else{
                Debug.Log(homie);
            } 

        }
        else if(other.gameObject.tag == "Enemy")
        {
            // call the damage function of the enemy
        }
    }
}
