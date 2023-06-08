using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloorNumHandler : MonoBehaviour
{
    public FloorManager fm;

    private int cRoom;

    public TMP_Text RoomNum;
    // Start is called before the first frame update
    void Start()
    {
        cRoom = (fm.currentRoom + 1);

    }

    // Update is called once per frame
    void Update()
    {
        cRoom = (fm.currentRoom + 1);
        RoomNum.SetText(cRoom.ToString());
    }
}
