using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    [SerializeField] private Data myData;

    private void Start()
    {
        myData._score = 0;
    }
}
