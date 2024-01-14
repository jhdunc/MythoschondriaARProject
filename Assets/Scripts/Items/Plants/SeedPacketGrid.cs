using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPacketGrid : MonoBehaviour
{
    public GameObject[] itemList;
    public GameObject[] spawnPoint;
    private int spawnCount;

    private void Start()
    {
        SpawnSeeds();
    }
    private void SpawnSeeds()
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            GameObject instanceObject = GameObject.Instantiate(itemList[i], spawnPoint[i].transform.position, spawnPoint[i].transform.rotation);

        }
    }

}



