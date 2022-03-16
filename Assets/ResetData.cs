using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    [SerializeField] private Data mydata;

    // Start is called before the first frame update
    void Start()
    {
        mydata._score = 0;
        mydata.indexScene = 0;
    }
}
