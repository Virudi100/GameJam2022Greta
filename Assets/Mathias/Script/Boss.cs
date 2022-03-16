using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject bulletExit;

    private GameObject newBullet;
    private RaycastHit rayHit;
    private bool canShoot = true;
    private int detectionIndex = 60;

    [SerializeField] private GameObject projectile;
    private float shootSpeed = 1f;
    public bool isAgressive = true;
    
    void Update()
    {
        if(isAgressive == true)
        {
            IsPlayerDetected();
        }
        
    }

    private void IsPlayerDetected()
    {
        Vector3 direction = Vector3.Normalize(player.transform.position - boss.transform.position);

        if (Physics.Raycast(boss.transform.position, direction, out rayHit, detectionIndex))
        {
            if (rayHit.collider.gameObject.CompareTag("Player"))
            {
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z) * Time.deltaTime);

                    if (canShoot == true)
                    {
                        canShoot = false;
                        StartCoroutine(Fire());
                    }
                }
            }
            Debug.DrawRay(boss.transform.position, direction, Color.green);
        }
    }

    IEnumerator Fire()
    {
        newBullet = Instantiate(projectile, bulletExit.transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(bulletExit.transform.forward * shootSpeed);
        newBullet.transform.parent = null;

        yield return new WaitForSeconds(2);
        canShoot = true;
    }
}
