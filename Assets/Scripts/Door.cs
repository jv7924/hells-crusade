using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private BoxCollider2D boxCollider;

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
        //// For testing
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
        StartCoroutine(DisableCollider());
    }
    
    private IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(1f);
        boxCollider.enabled = false;
    }
}
