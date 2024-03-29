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
    [SerializeField]
    private int floorNumber;

    public int currentRoom;
    private bool debugging;

    public static Action OnRoomClear;
    
    public UnityEvent OnEnemyDeath;

    void Start()
    {
        OnEnemyDeath = new UnityEvent();
        currentRoom = 0;
        setupRoom();
        debugging = GameManager.Instance.debugMode;
    }

    private void FixedUpdate()
    {

    }

    public void advanceRooms()
    {
        GameManager.Instance.RefreshPlayers.Invoke();
        if(debugging){Debug.Log("players refreshed");}
        roomControllers[currentRoom].gameObject.SetActive(false);
        if(debugging){Debug.Log("room deactivated");}
        currentRoom++;

        if(currentRoom < roomControllers.Length){
            setupRoom();
            if(debugging){Debug.Log("room loaded");}
        }
        else {
            GameManager.Instance.AdvanceFloors();
        }

    }

    private void setupRoom(){
            roomControllers[currentRoom].gameObject.SetActive(true);
            floorCam.transform.position = roomControllers[currentRoom].cameraLocation.position;
            floorCam.orthographicSize = roomControllers[currentRoom].cameraScale;
            if(debugging){Debug.Log("camera moved");}
            Vector2 spawnT = roomControllers[currentRoom].playerSpawn.position;
            
            spawnT.y += spawnOffset;

            if(currentRoom == 0){
                GameManager.Instance.SpawnPlayer(1, spawnT);
                spawnT.y -= 2 * spawnOffset;
                GameManager.Instance.SpawnPlayer(2, spawnT);
            }
            else{
                GameManager.Instance.MovePlayer(1, spawnT);
                if(debugging){Debug.Log("moved player1");}
                spawnT.y -= 2 * spawnOffset;
                GameManager.Instance.MovePlayer(2, spawnT);
                if(debugging){Debug.Log("moved player2");}
        }

            roomControllers[currentRoom].populateRoom();
            if(debugging){Debug.Log("room populated");}
    }
}
