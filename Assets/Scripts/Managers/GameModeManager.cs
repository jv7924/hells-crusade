using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance;

    [SerializeField, Tooltip("Choose the first level")]
    private string localScene;
    // [SerializeField]
    // private string test;  // Should be the loading screen scene

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else 
        {
            Destroy(this);
        }
    }

    public enum GameMode
    {
        ONLINE, 
        LOCAL
    }

    public static GameMode gameMode;

    public void LocalGame()
    {
        gameMode = GameMode.LOCAL;
        SceneManager.LoadScene(localScene);
    }

    // public void OnlineGame()
    // {
    //     gameMode = GameMode.ONLINE;
    //     SceneManager.LoadScene(onlineScene);
    // }
}
