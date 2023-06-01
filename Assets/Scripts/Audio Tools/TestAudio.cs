using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AudioManager.Instance.Play("SpearSuccess");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.Instance.Play("SpearCollide");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AudioManager.Instance.Play("EnemyFootstep");
        }
    }
}
