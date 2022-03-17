using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private float speed = 250f;
    private Rigidbody rb;
    private bool isPlaying = true;
    [SerializeField] private GameObject stars;
    [SerializeField] private AudioSource playerDeathSound;


    public delegate void Trigger();
    public static event Trigger trigger;

    [SerializeField] private string actualLevel;


    void Start()
    {
        Time.timeScale = 1;
        isPlaying = true;
        stars.SetActive(false);
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        IAEnemi.hit += KO;
    }

    private void OnDisable()
    {
        IAEnemi.hit -= KO;
    }

    void Update()
    {
        if (isPlaying == true)                  //Bloque les inputs quand le joueur est KO
        {
            if (Input.GetKey(KeyCode.Z))        //Inputs
            {
                rb.AddForce(Vector3.forward * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(Vector3.back * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                rb.AddForce(Vector3.left * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector3.right * speed * Time.deltaTime);
            }
        }
    }

    public void KO()
    {
        playerDeathSound.Play();
        isPlaying = false;

        stars.SetActive(true);      //Active les étoiles

        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        actualLevel = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(actualLevel);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SpawnDoor"))    //Quand le joueur passe a travers une porte de spawn d'ennemi, lance le trigger 
        {
            trigger?.Invoke();
        }
    }
}
