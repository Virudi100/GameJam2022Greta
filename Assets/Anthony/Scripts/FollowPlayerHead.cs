using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerHead : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset = new Vector3(0,2,0);
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        gameObject.transform.position = player.transform.position + offset; 
    }
}
