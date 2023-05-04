using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    public float wait;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawner", wait, wait/4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Spawner()
    {
        Instantiate(enemyPrefab, new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0), Quaternion.identity);
    }
}
