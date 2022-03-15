using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private float speed = 240f;
    private Rigidbody rb;
    private float xSpeed = 210f;
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
                rb.AddForce(new Vector3(xSpeed * Time.deltaTime, 0, speed * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(new Vector3(-xSpeed * Time.deltaTime, 0, -speed * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.Q))
            {
                rb.AddForce(new Vector3(-speed * Time.deltaTime, 0, 0));
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }
    }

    private void KO()
    {
        isPlaying = false;
        stars.SetActive(true);
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Level1");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SpawnDoor"))
        {
            Player.trigger.Invoke();
        }
    }
}
