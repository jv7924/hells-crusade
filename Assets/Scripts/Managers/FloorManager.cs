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

    private int currentRoom;
    private int spawnOffset;
    // Start is called before the first frame update
    void Start()
    {
        currentRoom = 0;
        floorCam.transform.position = cameraPositions[currentRoom].position;
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
        // GameManager.Instance.movePlayer(1, )
    }


}
