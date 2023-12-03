using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPacketGrid : MonoBehaviour
{
    public List<GameObject> itemList = new List<GameObject>();
    [SerializeField] GameObject[] spawnPoint;
    private int spawnCount;

    private void Start()
    {
        SpawnSeeds();
        spawnCount = 0;
    }
    private void SpawnSeeds()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            GameObject instanceObject = GameObject.Instantiate(itemList[i], spawnPoint[spawnCount].transform.position, spawnPoint[spawnCount].transform.rotation);
            spawnCount++;
            if (spawnCount > itemList.Count)
            {
                spawnCount = 0;
            }
        }
    }
}



