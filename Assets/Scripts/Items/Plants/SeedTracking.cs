using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTracking : MonoBehaviour

{

    // THIS SCRIPT IS INTENDED TO LIMIT SEEDS IN WORLD
    // currently this script is not able to keep up with players spamming seeds which every single test player has done

    public List<GameObject> worldItemList; // list of gameobjects to store seeds in world
    public SeedInfo seedInfo; // be able to set as specific instance of script on an object
    private GameObject tarItem; // item that will be destroyed
    public bool cleanup; // bool to enable/disable seed grab while the destroy code is still running
    private int ID;

    public void Start()
    {
        ID = GetComponent<SeedInfo>().itemInfo.itemID;
        seedInfo = GetComponent<SeedInfo>(); // get SeedInfo.cs reference from gameobject that this is attached to

        cleanup = false; // not in destroy code at start

    }
    public void UpdateList() // method to update the list of game objects in the world
    {
        worldItemList = new List<GameObject>(); // delete the current set of objects in the list

        // create a list of current seeds of this type in the world
        // this list is created by looking at the game objects in the Hierarchy from top to bottom
        // items are spawned top to bottom, so the first object it encounters will be the oldest object
        foreach (GameObject seedObj in GameObject.FindGameObjectsWithTag("seed")) // for every object that has the tag "seed"
        {
            Debug.Log("seed" + seedObj.GetComponent<SeedInfo>().itemInfo.itemID);
            if (seedObj.GetComponent<SeedInfo>().itemInfo.itemID == ID) // if the found object's itemID is the same as this object's itemID, then:
            {
                worldItemList.Add(seedObj); // add the gameobject to the list
            }
    }
         
    }
    public void ItemDestroy()  // method to destroy excess seeds in the world
    {
        if (worldItemList.Count > seedInfo.seedMax) // so long as there are more seeds in the world than the max allowed by the seed's Max variable, run the following:
        {
            cleanup = true; // change bool to true so that the onGrab function in SeedPackageSetup.cs does not run (prevents spam)
            UpdateList(); // update the list of seeds currently in the world
            tarItem = worldItemList[0]; // set tarItem variable to the oldest instance of the seed
            Destroy(tarItem); // delete the oldest seed object.
        }
        if (worldItemList.Count <= seedInfo.seedMax) // once the while script is finished, set cleanup to false (I THINK this works..)
        { 
            cleanup = false;
        }
    }
    public void Update() // update list when space is pressed (debugging/test)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateList();
        }
    }
}

