using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private AudioSource cam;
    [SerializeField] private AudioClip victory;
    [SerializeField] private AudioClip bossMusic;

    private void Start()
    {
        cam.clip = bossMusic;
        winCanvas.SetActive(false);
        cam.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam.clip = victory;
            cam.Play();
            winCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void RetryBeginning()
    {
        SceneManager.LoadScene(0);    
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
