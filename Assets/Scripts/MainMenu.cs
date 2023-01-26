using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void sceneGame()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
