using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followcam : MonoBehaviour
{
    public GameObject player;
   
    void Update()
    {
        gameObject.transform.position = player.transform.position;      //Suit la position du joueur
    }
}
