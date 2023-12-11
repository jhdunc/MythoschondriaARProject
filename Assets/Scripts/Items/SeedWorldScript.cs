using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedWorldScript : MonoBehaviour
{

    public List<GameObject> worldItemList = new List<GameObject>();
    private int seedMx;
    private int ID;
    private GameObject tarItem;

    public void Start()
    {
        ID = GetComponent<SeedPackageSetup>().itemID;
        seedMx = GetComponent<SeedPackageSetup>().seedMax;

    }
    public void UpdateList()
    {
        worldItemList.Clear();
        foreach (GameObject seedObj in GameObject.FindGameObjectsWithTag("seed"))
        {
            if (seedObj.GetComponent<SeedPackageSetup>().itemID == ID)
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UpdateList();
        }
    }
}
