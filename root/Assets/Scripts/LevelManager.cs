using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string name)
    {
        System.Threading.Thread.Sleep(500);
        SceneManager.LoadScene(name);
    }


    public void ReplayLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }

    

    public void QuitRequest()
    {
        Application.Quit();
    }
}
