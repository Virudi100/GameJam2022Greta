using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "create my scriptable object")]
public class Data : ScriptableObject
{
    public int _score;              //Stock le score
    public int indexScene;          //Stock l'index des scenes
}
