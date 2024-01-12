using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPacketGrid : MonoBehaviour
{
    public List<GameObject> itemList = new List<GameObject>();
    public GameObject[] spawnPoint;
    private int spawnCount;

    private void Start()
    {
        SpawnSeeds();
    }
    private void SpawnSeeds()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            GameObject instanceObject = GameObject.Instantiate(itemList[i], spawnPoint[i].transform.position, spawnPoint[i].transform.rotation);


        }
    }

}



