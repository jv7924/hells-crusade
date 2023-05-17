using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemies;
    [SerializeField] public Transform playerSpawn;
    [SerializeField] public Transform cameraLocation;

    private int deathCount;

    void OnEnable(){
        FloorManager.Instance.OnEnemyDeath.AddListener(CalcEnemies);
        deathCount = 0;
    }

    // activates the enemies in the room
    public void populateRoom(){
        foreach(GameObject e in Enemies){
            e.SetActive(true);
        }
    }

    void CalcEnemies(){
        deathCount++;
        if(deathCount == Enemies.Length){
            FloorManager.Instance.advanceRooms();
        }
    }

    void OnDisable(){
        FloorManager.Instance.OnEnemyDeath.RemoveListener(CalcEnemies);
    }
}
