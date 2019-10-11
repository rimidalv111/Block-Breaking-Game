using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadWinScene()
    {
        //SceneManager.LoadScene(2);
        int smanager = SceneManager.GetSceneAt(2).buildIndex;
        SceneManager.LoadScene(smanager);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
