using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerHead : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 offset = new Vector3(0,2,0);
    private void Update()
    {
        gameObject.transform.position = player.transform.position + offset; 
    }
}
