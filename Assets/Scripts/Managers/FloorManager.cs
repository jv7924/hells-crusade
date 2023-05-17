using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    // Start is called before the first frame update
    void Start()
    {
        currentRoom = 0;
        GameManager.Instance.SpawnPlayer(1);
        GameManager.Instance.SpawnPlayer(2);
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
        roomControllers[currentRoom].gameObject.SetActive(false);
        currentRoom++;

        if(currentRoom < roomControllers.Length){
            setupRoom();
        }

    }

    private void setupRoom(){
            roomControllers[currentRoom].gameObject.SetActive(true);
            floorCam.transform.position = roomControllers[currentRoom].cameraLocation.position;
            Vector2 spawnT = roomControllers[currentRoom].playerSpawn.position;
            spawnT.y += spawnOffset;
            GameManager.Instance.MovePlayer(1, spawnT);
            spawnT.y -= 2 * spawnOffset;
            GameManager.Instance.MovePlayer(2, spawnT);

            roomControllers[currentRoom].populateRoom();
    }
}
