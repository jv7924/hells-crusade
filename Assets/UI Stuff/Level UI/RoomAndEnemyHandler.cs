using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomAndEnemyHandler : MonoBehaviour
{
    [SerializeField] RoomController[] roomControllers;
    public FloorManager fm;
    private RoomController rm;

    private int cRoom;

    public TMP_Text roomNum;
    public TMP_Text enemyKilled;
    public TMP_Text enemyTotal;

    private GameObject player1;
    private GameObject player2;


    private bool player1Thrown;
    private bool player2Thrown;

    public Image player1UI;
    public Image player2UI;

    public Sprite player1base;
    public Sprite player2base;

    public Sprite player1power;
    public Sprite player2power;

    // Start is called before the first frame update
    void Start()
    {
        cRoom = fm.currentRoom;
        rm = roomControllers[cRoom];
        enemyTotal.SetText((rm.Enemies.Length).ToString());

    }

    // Update is called once per frame
    void Update()
    {
        player1 = GameObject.Find("Player 1(Clone)");
        player2 = GameObject.Find("Player 2(Clone)");

        player1Thrown = player1.GetComponent<SpearThrow>().canThrow;
        player2Thrown = player2.GetComponent<SpearThrow>().canThrow;

        enemyTotal.SetText((rm.Enemies.Length).ToString());
        enemyKilled.SetText((rm.deathCount).ToString());
        cRoom = (fm.currentRoom);
        rm = roomControllers[cRoom];
        roomNum.SetText((cRoom + 1).ToString());

        if(player1Thrown == true)
        {
            player1UI.sprite = player1power;
        }

        else if(player1Thrown == false)
        {
            player1UI.sprite = player1base;
        }

        if (player2Thrown == true)
        {
            player2UI.sprite = player2power;
        }

        else if (player2Thrown == false)
        {
            player2UI.sprite = player2base;
        }
    }
}
