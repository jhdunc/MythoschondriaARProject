using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTracking : MonoBehaviour

{

    public List<GameObject> worldItemList = new List<GameObject>();
    private int seedMx;
    private int ID;
    private GameObject tarItem;

    public void Start()
    {
        ID = GetComponent<SeedInfo>().itemID;
        seedMx = GetComponent<SeedInfo>().seedMax;

    }
    public void UpdateList()
    {
        worldItemList.Clear();
        foreach (GameObject seedObj in GameObject.FindGameObjectsWithTag("seed"))
        {
            if (seedObj.GetComponent<SeedInfo>().itemID == ID)
            {
                worldItemList.Add(seedObj);
            }
        }
    }
    public void ItemDestroy()
    {
        while (worldItemList.Count > seedMx)
        {
            UpdateList();
            tarItem = worldItemList[0];
            Destroy(tarItem);
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateList();
        }
    }
}

