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

        if (playerStatuses[2/playerNumber] == PlayerStatus.DOWN)
        {
            p1.GetComponent<PlayerController>().Die();
            p2.GetComponent<PlayerController>().Die();
            // yield the amount of time it takes for both animations to complete

            endGame();
        }

    }

    private void endGame()
    {
        // might want to switch this to changing the scene to a loss screen
        Application.Quit();
    }
}
