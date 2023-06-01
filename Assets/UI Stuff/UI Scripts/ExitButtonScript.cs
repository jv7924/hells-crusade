using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonScript : MonoBehaviour
{
    [SerializeField] int floorOneIndex;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(floorOneIndex);
    }
}
