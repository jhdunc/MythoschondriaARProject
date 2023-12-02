using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedSpawner : MonoBehaviour
{
    public GameObject seedPackage;
    public Transform[] spawnPoints = new Transform[1];
    [SerializeField] private int spawnCount;

    public void seedSpawn()
    {
        GameObject instanceObject = GameObject.Instantiate(seedPackage, spawnPoints[spawnCount].transform.position, spawnPoints[spawnCount].transform.rotation);
        

    }
    void Start()
    {
        spawnCount = 0;
    }

    void Update()
    {
        if (spawnCount < spawnPoints.Length)
        {
            seedSpawn();
            spawnCount++;
        }
    }

}
