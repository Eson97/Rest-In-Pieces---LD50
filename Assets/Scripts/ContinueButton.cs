using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
