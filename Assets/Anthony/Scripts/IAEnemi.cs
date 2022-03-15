using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemi : MonoBehaviour
{
    private NavMeshAgent navmesh;
    [SerializeField] private GameObject player;
    private bool isAggressive = true;

    // Start is called before the first frame update
    void Start()
    {
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
            navmesh.SetDestination(-player.transform.position);
        
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(15);
        isAggressive = false;
        navmesh.speed = 40;
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }


}