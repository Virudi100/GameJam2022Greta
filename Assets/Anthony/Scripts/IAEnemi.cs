using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemi : MonoBehaviour
{
    private NavMeshAgent navmesh;
    private GameObject player;
    private bool isAggressive = true;
    private Transform pointFuite;

    public delegate void Hit();
    public static event Hit hit;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().Play(); 
        pointFuite = GameObject.FindGameObjectWithTag("FuitePoint").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        navmesh = GetComponent<NavMeshAgent>();
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        if (isAggressive == true)
        {
            navmesh.SetDestination(player.transform.position);
        }
        else
        {
            navmesh.SetDestination(pointFuite.position);

        }
            
        
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(9);
        isAggressive = false;
        navmesh.speed = 40;
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            navmesh.speed = 0;
            hit?.Invoke();
            
        }
    }


}
