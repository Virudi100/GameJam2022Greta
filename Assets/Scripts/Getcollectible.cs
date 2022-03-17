using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getcollectible : MonoBehaviour
{
    public Data myData;

    public Camera camera;

    [SerializeField] private AudioSource collectiblesound;


    void Update()
    {
        GetmousePosition();
    }

    private void GetmousePosition()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);     //Place le raycast par rapport a la position de la souris

        Debug.DrawRay(ray.origin,ray.direction,Color.red);

        if (Physics.Raycast(ray.origin,ray.direction,out hit))
        {
            if (hit.collider.gameObject.CompareTag("collectible"))  //Si le raycast entre en collision avec un collectible
            {
                collectiblesound.Play();                            //Joue le son du collectible
            
                Destroy(hit.collider.gameObject);                   //Detruit le collectible

                myData._score++;                                    //Ajoute 1 Point au Score
            }
        }
    }
}
