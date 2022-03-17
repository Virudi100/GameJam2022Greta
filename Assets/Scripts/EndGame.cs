using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private AudioSource cam;

    [Header("Sounds")]
    [SerializeField] private AudioClip victory;
    [SerializeField] private AudioClip bossMusic;

    private void Start()
    {
        cam.clip = bossMusic;           //Joue la musique du niveau
        cam.Play();

        winCanvas.SetActive(false);     //Désactive le canvas de victoire
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam.clip = victory;         //Joue la musique de Victoire
            cam.Play();

            winCanvas.SetActive(true);  //Active le canvas de victoire

            Time.timeScale = 0;         //Mes la pause
        }
    }

    public void RetryBeginning()        //Renvoie au menu
    {
        SceneManager.LoadScene(0);    
    }

    public void Quit()                  //Ferme le jeu
    {
        Application.Quit(); 
    }
}
