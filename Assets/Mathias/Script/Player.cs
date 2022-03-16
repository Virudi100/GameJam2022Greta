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

    public delegate void Trigger();
    public static event Trigger trigger;


    void Start()
    {
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
        if (isPlaying == true)
        {
            if (Input.GetKey(KeyCode.Z))
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

    private void KO()
    {
        isPlaying = false;
        stars.SetActive(true);
        StartCoroutine(Restart());
    }

    public void KOBoss()
    {
        isPlaying = false;
        stars.SetActive(true);
        StartCoroutine(RestartBoss());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main");
    }

    IEnumerator RestartBoss()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("BossFight");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SpawnDoor"))
        {
            Player.trigger.Invoke();
        }
    }
}
