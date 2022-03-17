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
        Time.timeScale = 1;         //Enleve la pause
    }

    public void Demarrer() //Demarre le jeu
    {   
        Reset();
        SceneManager.LoadScene(starting.indexScene);
    }

    public void Reset()     //Reset les scores
    {
        starting.indexScene = 1;
        starting._score = 0;
    }

    public void OnApplicationQuit() //Ferme l'application
    {
        Application.Quit();
    }
}
