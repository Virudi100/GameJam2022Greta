using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float speed = 100f;
    public float jump = 100f;
    public Rigidbody rb;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    
    void Update()
   
    {
        if (Input.GetKey(KeyCode.Z))
        {
           rb.AddForce(new Vector3(0,0,speed*Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0,0,-speed*Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(new Vector3(speed*Time.deltaTime,0,0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(-speed*Time.deltaTime,0,0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
           rb.AddForce(new Vector3(0,jump*Time.deltaTime,0));
        }
            
        
    }
}
