using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemies;
    [SerializeField] public float cameraScale;
    [SerializeField] public Transform playerSpawn;
    [SerializeField] public Transform cameraLocation;


    private int deathCount;
    private bool debugging;

    void Start(){
        debugging = GameManager.Instance.debugMode;
    }

    void OnEnable(){
        FloorManager.Instance.OnEnemyDeath.AddListener(CalcEnemies);
        deathCount = 0;
        if(debugging){Debug.Log("listening");}
    }

    void FixedUpdate()
    {
        if (deathCount == Enemies.Length && Enemies.Length > 0)
        {
            FloorManager.Instance.advanceRooms();
        }
    }

    // activates the enemies in the room
    public void populateRoom(){
        foreach(GameObject e in Enemies){
            e.SetActive(true);
        }
    }

    void CalcEnemies(){
        deathCount++;
    }

    void OnDisable(){
        FloorManager.Instance.OnEnemyDeath.RemoveListener(CalcEnemies);
        if(debugging){Debug.Log("no longer listening");}
    }
}
