using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private float speed = 240f;
    private float jump = 5f;
    private Rigidbody rb;
    private float xSpeed = 210f;
    private bool canjump = true;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    
    void Update()
   
    {
        if (Input.GetKey(KeyCode.Z))
        {
           rb.AddForce(new Vector3(xSpeed*Time.deltaTime,0,speed*Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(-xSpeed*Time.deltaTime,0,-speed*Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(new Vector3(-speed*Time.deltaTime,0,0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(speed*Time.deltaTime,0,0));
        }

        /*if (Input.GetKeyDown(KeyCode.Space) && canjump == true)
        {
            
            canjump = false;
            
            StartCoroutine(isjump());
        }*/
        
        
    }

    /*public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canjump = true;
        }
    }*/

    /*public IEnumerator isjump()
    {
        
        rb.AddForce(new Vector3(0,2,0)*jump,ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);

    }*/
}
