using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [Header("Main Characters")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject boss;

    [Header("Bullet Exit")]
    [SerializeField] private GameObject bulletExit;
    
    [Header("Sprites")]
    [SerializeField] private GameObject happyBoss;
    [SerializeField] private Sprite heartsprite;

    
    private RaycastHit rayHit;
    private bool canShoot = true;
    private int detectionIndex = 60;                        //Distance de detection du boss

    [SerializeField] private GameObject projectile;         //Prefab de la munition tiré par le boss

    private float shootSpeed = 1f;                          //Vitesse d'envoie de la balle
    public bool isAgressive = true;                         //Si le boss est en phase de combat

    [Header("Porte de sortie")]
    [SerializeField] private GameObject door;               
    
    void Update()
    {
        if (isAgressive == true)    //Est ce que le boss est en phase de combat ?
        {
            IsPlayerDetected();
        }
        else
        {
            happyBoss.GetComponent<Image>().sprite = heartsprite;
            Destroy(door);
        }
    }

    private void IsPlayerDetected()
    {

        Vector3 direction = Vector3.Normalize(player.transform.position - boss.transform.position);     //Calcule la distance entre le joueur et le boss

        if (Physics.Raycast(boss.transform.position, direction, out rayHit, detectionIndex))
        {
            if (rayHit.collider.gameObject.CompareTag("Player"))        //Si le raycast touche le joueur
            {
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z) * Time.deltaTime);    //Le boss regarde le joueur

                    if (canShoot == true)           //Si il peut tirer, tire et attend 2 sec avant de re-tirer
                    {
                        canShoot = false;
                        StartCoroutine(Fire());
                    }
                }
            }
            Debug.DrawRay(boss.transform.position, direction, Color.green);
        }
    }

    IEnumerator Fire()      //Intantie la ball vers l'avant du boss
    {
        GameObject newBullet = Instantiate(projectile, bulletExit.transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(bulletExit.transform.forward * shootSpeed);
        newBullet.transform.parent = null;

        yield return new WaitForSeconds(2);
        canShoot = true;
    }
}
