using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField]
    GameObject p1;
    [SerializeField]
    GameObject p2;

    [SerializeField]
    Camera mainCam;

    // things to keep track of
    public enum PlayerStatus {ALIVE, DOWN, DEAD};

    private PlayerStatus[] playerStatuses = { PlayerStatus.ALIVE, PlayerStatus.ALIVE };

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void downPlayer(int playerNumber)
    {
        playerStatuses[playerNumber] = PlayerStatus.DOWN;
        Debug.Log(playerNumber);
        Debug.Log("Down");

        if (playerStatuses[2/playerNumber] == PlayerStatus.DOWN)
        {
            p1.GetComponent<PlayerController>().Die();
            p2.GetComponent<PlayerController>().Die();
            // yield the amount of time it takes for both animations to complete

            endGame();
        }

    }

    // public Vector3 cursorPos()
    // {
    //     // will later change which input pos to return based on player number
    //     return mainCam.ScreenToWorldPoint(Input.mousePosition);
    // }

    private void endGame()
    {
        // will eventually change this to switching to game loss screen
        Application.Quit();
    }
}
