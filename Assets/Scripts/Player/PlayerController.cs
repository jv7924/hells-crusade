using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator playerAnimator;

    [SerializeField]
    int PlayerNumber;

    [SerializeField]
    PlayerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        // someone figure out how to initialize player number correctly lol
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        Down();
    }

    public void Die()
    {
        // playerAnimator death animation, then
        Destroy(gameObject);
    }

    private void Down()
    {
        GameManager.Instance.downPlayer(PlayerNumber);
        // play down animation
        // restrict movement
        Debug.Log("Hit");
    }

    public int GetPlayerNumber()
    {
        return PlayerNumber;
    }
}