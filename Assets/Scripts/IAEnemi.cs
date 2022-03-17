using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemi : MonoBehaviour
{
    private NavMeshAgent navmesh;       //Navmesh de l'ennemi
    private bool isAggressive = true;   //Si l'ennemi est agréssif
    private Transform pointFuite;       //Point de fuite des ennemis

    private GameObject player;
    
        //Event de "L'ennemi a touché le joueur"
    public delegate void Hit();
    public static event Hit hit;

    void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();                          //Joue le son de l'ennemi

        pointFuite = GameObject.FindGameObjectWithTag("FuitePoint").transform;  
        player = GameObject.FindGameObjectWithTag("Player");

        navmesh = GetComponent<NavMeshAgent>();

        StartCoroutine(Attack());
    }

    void Update()
    {
        if (isAggressive == true)       //Change la destination selon phase de l'ennemi
        {
            navmesh.SetDestination(player.transform.position);
        }
        else
        {
            navmesh.SetDestination(pointFuite.position);
        }
    }

    IEnumerator Attack()                //Poursuit le joueur pendant 9 sec puis fuit pendant 10 pour sortir de l'ecran et disparait
    {
        yield return new WaitForSeconds(9);
        isAggressive = false;
        navmesh.speed = 40;
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))   //Lance l'event de l'ennemis qui a toucher le joueur
        {
            navmesh.speed = 0;
            hit?.Invoke();
        }
    }
}
