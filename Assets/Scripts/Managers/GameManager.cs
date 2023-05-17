using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region "Singleton"
    public static GameManager Instance { get; private set; }

    void Awake()
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
    #endregion

    [SerializeField]
    GameObject[] Players;

    [SerializeField]
    Camera mainCam;
    
    [SerializeField]
    int nextFloor;

    // things to keep track of
    
    public enum PlayerStatus {ALIVE, DOWN, DEAD};

    // events
    public UnityEvent<int> EnemyHit = new UnityEvent<int>();
    public UnityEvent RefreshPlayers = new UnityEvent();

    private PlayerStatus[] playerStatuses = { PlayerStatus.ALIVE, PlayerStatus.ALIVE };


    private void Start(){
        RefreshPlayers.AddListener(onRefresh);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    // Player Management Functions
    public void SpawnPlayer(int playerNumber, Vector2 location)
    {
        Instantiate(Players[playerNumber - 1], location, Quaternion.identity);
    }

    public void MovePlayer(int playerNumber, Vector2 location)
    {
        Players[playerNumber - 1].transform.position = location;
    }

    public void refreshThrow(int playerNumber)
    {
        EnemyHit.Invoke(playerNumber);
    }

    public void downPlayer(int playerNumber)
    {
        playerStatuses[playerNumber - 1] = PlayerStatus.DOWN;
        Debug.Log(playerNumber);
        Debug.Log("Down");

        if (playerStatuses[2/playerNumber - 1] == PlayerStatus.DOWN)
        {
            Players[0].GetComponent<PlayerController>().Die();
            Players[1].GetComponent<PlayerController>().Die();
            // yield the amount of time it takes for both animations to complete

            endGame();
        }

    }

    // game state Management Functions
    public void AdvanceFloors(){
        SceneManager.LoadScene(nextFloor);
    }

    private void endGame(){
        // will eventually change this to switching to game loss screen
        Application.Quit();
    }

    private void onRefresh(){
        playerStatuses[0] = PlayerStatus.ALIVE;
        playerStatuses[1] = PlayerStatus.ALIVE;
    }
}
