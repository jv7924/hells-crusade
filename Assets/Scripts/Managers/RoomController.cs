using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemies;
    [SerializeField] public Transform playerSpawn;
    [SerializeField] public Transform cameraLocation;

    public UnityEvent OnEnemyDeath;

    private int deathCount;

    void Start(){
        OnEnemyDeath.AddListener(CalcEnemies);
        deathCount = 0;
    }

    // fills the room with enemies
    public void populateRoom(){
        deathCount = 0;
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
}
