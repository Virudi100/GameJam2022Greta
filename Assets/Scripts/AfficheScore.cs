using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfficheScore : MonoBehaviour
{
    [SerializeField] private Data myData;

    void Update()
    {
        //Recupère le score sur le scriptable object et l'affiche

        gameObject.GetComponent<Text>().text = (myData._score + " /10");
    }
}
