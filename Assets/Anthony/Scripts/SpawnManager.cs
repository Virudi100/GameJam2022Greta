using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] doors;
    int i = 0;

    private void OnEnable()
    {
        Player.trigger += spawnNextEnemies;
    }

    private void OnDisable()
    {
        Player.trigger -= spawnNextEnemies;
    }

    private void spawnNextEnemies()
    {
        switch (i)
        {
            case 0:
                spawnEnemies();
                break;

            case 1:
                spawnEnemies();
                break;

            case 2:
                spawnEnemies();
                break;

            case 3:
                spawnEnemies();
                break;
        }           
    }

    private void spawnEnemies()
    {
        doors[i].GetComponent<HisEnemis>().Enemies.SetActive(true);
        i++;
    }
}
