using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGland : MonoBehaviour
{
    [SerializeField] private GameObject boss;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gland"))       //Rend le boss gentil à l'impact du gland
        {
            Destroy(collision.gameObject);
            boss.GetComponent<Boss>().isAgressive = false;
        }
    }
}
