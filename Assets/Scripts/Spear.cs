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
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
