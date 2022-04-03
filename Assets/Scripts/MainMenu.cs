using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        //TODO Change by real scene
        SceneManager.LoadScene("TestScene");
    }

    public void Credits()
    {
        //
        SceneManager.LoadScene("TestScene");
    }

    public void Instructions()
    {
        //Todo change by instruccions scene
        SceneManager.LoadScene("TestScene");
    }
}
