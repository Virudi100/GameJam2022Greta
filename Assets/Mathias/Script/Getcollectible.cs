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
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction,Color.red);

        if (Physics.Raycast(ray.origin,ray.direction,out hit))
        {
            print("istouch "+hit.collider.gameObject.tag);
            if (hit.collider.gameObject.CompareTag("collectible"))
            {
                collectiblesound.Play();
                print("collidecollectible");
                Destroy(hit.collider.gameObject);
                myData._score++;
            }
        }
    }
}
