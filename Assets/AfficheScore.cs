using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfficheScore : MonoBehaviour
{
    [SerializeField] private Data myData;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = (myData._score + " /10");
    }
}
