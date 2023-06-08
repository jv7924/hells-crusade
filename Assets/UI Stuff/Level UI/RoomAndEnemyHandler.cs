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
    private int enemyTotal;
    private int enemyKilled;

    public TMP_Text RoomNum;
    public TMP_Text EnemyKilled;
    public TMP_Text EnemyTotal;
    // Start is called before the first frame update
    void Start()
    {
        cRoom = fm.currentRoom;
        rm = roomControllers[cRoom];
        EnemyTotal.SetText((rm.Enemies.Length).ToString());

    }

    // Update is called once per frame
    void Update()
    {
        EnemyTotal.SetText((rm.Enemies.Length).ToString());
        EnemyKilled.SetText((rm.deathCount).ToString());
        cRoom = (fm.currentRoom);
        rm = roomControllers[cRoom];
        RoomNum.SetText((cRoom + 1).ToString());
    }
}
