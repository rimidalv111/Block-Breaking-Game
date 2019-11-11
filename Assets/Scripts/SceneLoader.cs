using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        GameObject.Destroy(GameObject.Find("GameSession")); //destroy our DontDestroyOnLoad
        GameObject.Destroy(GameObject.Find("LevelHandler")); //destroy our DontDestroyOnLoad
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevelScene(int levelid)
    {
        SceneManager.LoadScene(levelid);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
