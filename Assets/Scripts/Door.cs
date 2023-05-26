using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private BoxCollider2D boxCollider;

    // Might want to switch CloseDoor to trigger so that you can set a position as a trigger
    // I.E. when players touch the trigger, the doors close

    private void OnEnable()
    {
        // Subscribe to event here.
        FloorManager.OnRoomClear += OpenDoor;
    }

    private void OnDisable()
    {
        FloorManager.OnRoomClear -= OpenDoor;
    }

    void Update()
    {
        // For testing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenDoor();
        }
    }

    // Event that triggers when all enemies in a room are defeated.
    private void OpenDoor()
    {
        Debug.Log("Opening Door");
        animator.SetBool("Room Cleared", true);
        //StartCoroutine(DisableCollider());
    }
    
    private IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(1f);
        boxCollider.enabled = false;
    }
}
