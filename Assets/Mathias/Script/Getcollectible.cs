using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getcollectible : MonoBehaviour
{
    private int score;
    public Camera camera;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        GetmousePosition();
    }

    private void GetmousePosition()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(ray.origin,ray.direction,Color.red);

        if (Physics.Raycast(ray.origin,ray.direction,out hit))
        {
            print("istouch "+hit.collider.gameObject.tag);
            if (hit.collider.gameObject.CompareTag("collectible"))
            {
                print("collidecollectible");
                Destroy(hit.collider.gameObject);
                score++;
            }
        }
    }
}
