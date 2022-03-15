using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float speedrotate = 500f;
    void Update()
    {
        rotation();
    }

    // Update is called once per frame
    private void rotation()
    {
        gameObject.transform.Rotate(0, 1 * speedrotate * Time.deltaTime, 0); 
    }
}
