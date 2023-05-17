using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FloorManager : MonoBehaviour
{
    #region "Singleton"
    public static FloorManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion "Singleton"

    [SerializeField] RoomController[] roomControllers;
    [SerializeField]
    private Camera floorCam;
    [SerializeField]
    private int spawnOffset;

    private int currentRoom;
    
    public UnityEvent OnEnemyDeath;
    // Start is called before the first frame update
    void Start()
    {
        OnEnemyDeath = new UnityEvent();
        currentRoom = 0;
        setupRoom();
    }

    private void FixedUpdate()
    {
        // test
        if(Input.GetKeyDown(KeyCode.Space)) {
            advanceRooms();
        }
    }

    public void advanceRooms()
    {
        GameManager.Instance.RefreshPlayers.Invoke();
        roomControllers[currentRoom].gameObject.SetActive(false);
        currentRoom++;

        if(currentRoom < roomControllers.Length){
            setupRoom();
        }
        else {
            GameManager.Instance.AdvanceFloors();
        }

    }

    private void setupRoom(){
            roomControllers[currentRoom].gameObject.SetActive(true);
            floorCam.transform.position = roomControllers[currentRoom].cameraLocation.position;
            Vector2 spawnT = roomControllers[currentRoom].playerSpawn.position;
            spawnT.y += spawnOffset;

            if(currentRoom == 0){
                GameManager.Instance.SpawnPlayer(1, spawnT);
                spawnT.y -= 2 * spawnOffset;
                GameManager.Instance.SpawnPlayer(2, spawnT);
            }
            else{
                GameManager.Instance.MovePlayer(1, spawnT);
                spawnT.y -= 2 * spawnOffset;
                GameManager.Instance.MovePlayer(2, spawnT);
            }

            roomControllers[currentRoom].populateRoom();
    }
}
