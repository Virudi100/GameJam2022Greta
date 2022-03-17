using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))           //Si rentre en collision avec le joueur, mes KO le joueur
        {
            collision.gameObject.GetComponent<Player>().KO();
        }

        Destroy(gameObject);                                    //A n'importe quelle collision détruit la munition
    }
}
