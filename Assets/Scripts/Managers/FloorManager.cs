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

    [SerializeField]
    private Transform[] cameraPositions;
    [SerializeField] 
    private Transform[] playerSpawns;
    [SerializeField]
    private Camera floorCam;
    [SerializeField]
    private int spawnOffset = 2;

    private int currentRoom;
    
    // Start is called before the first frame update
    void Start()
    {
        currentRoom = 0;
        floorCam.transform.position = cameraPositions[currentRoom].position;
        Vector2 spawnT = playerSpawns[currentRoom].position;
        spawnT.y += spawnOffset;
        GameManager.Instance.SpawnPlayer(1, spawnT);
        spawnT.y -= 2*spawnOffset;
        GameManager.Instance.SpawnPlayer(2, spawnT);
    }

    private void Update()
    {
        // test
        if(Input.GetKeyDown(KeyCode.Space)) {
            advanceRooms();
        }
    }

    public void advanceRooms()
    {
        currentRoom++;
        floorCam.transform.position = cameraPositions[currentRoom].position;
        Vector2 spawnT = playerSpawns[currentRoom].position;
        spawnT.y += spawnOffset;
        GameManager.Instance.MovePlayer(1, spawnT);
        spawnT.y -= 2 * spawnOffset;
        GameManager.Instance.MovePlayer(2, spawnT);
    }


}
