using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Data starting;

    public void Start()
    {
        Time.timeScale = 1;
    }

    public void Demarrer()
    {   
        Reset();
        SceneManager.LoadScene(starting.indexScene);
    }

    public void Reset()
    {
        starting.indexScene = 1;
        starting._score = 0;
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
