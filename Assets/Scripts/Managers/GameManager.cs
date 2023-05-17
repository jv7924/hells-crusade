using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // things to keep track of
    public enum PlayerStatus {ALIVE, DOWN, DEAD};

    private PlayerStatus[] playerStatuses = { PlayerStatus.ALIVE, PlayerStatus.ALIVE };



    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void SpawnPlayer(int playerNumber)
    {
        Instantiate(Players[playerNumber - 1], transform.position, Quaternion.identity);
    }

    public void MovePlayer(int playerNumber, Vector2 location)
    {
        Players[playerNumber - 1].transform.position = location;
    }

    public void downPlayer(int playerNumber)
    {
        playerStatuses[playerNumber - 1] = PlayerStatus.DOWN;
        Debug.Log(playerNumber);
        Debug.Log("Down");

        if (playerStatuses[2/playerNumber] == PlayerStatus.DOWN)
        {
            Players[0].GetComponent<PlayerController>().Die();
            Players[1].GetComponent<PlayerController>().Die();
            // yield the amount of time it takes for both animations to complete

            endGame();
        }

    }

    private void endGame()
    {
        // will eventually change this to switching to game loss screen
        Application.Quit();
    }
}
