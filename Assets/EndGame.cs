using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;

    private void Start()
    {
        winCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void RetryBeginning()
    {
        SceneManager.LoadScene(1);    
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
