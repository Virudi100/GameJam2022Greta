using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerHead : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset = new Vector3(0,2,0);

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    //Trouve le joueur dans la scene
    }

    private void Update()
    {
        gameObject.transform.position = player.transform.position + offset; //Place les étoiles au dessus de la tete du joueur
    }
}
