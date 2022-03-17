using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float speedrotate = 50f;

    void Update()
    {
        rotation();         //Fait tourné l'objet sur lui meme 
    }

    private void rotation()
    {
        gameObject.transform.Rotate(0, 1 * speedrotate * Time.deltaTime, 0); 
    }
}
