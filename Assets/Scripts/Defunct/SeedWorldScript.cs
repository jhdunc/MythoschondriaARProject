using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedWorldScript : MonoBehaviour
{
    // THIS SCRIPT IS INTENDED TO LIMIT SEEDS IN WORLD
    // currently this script is not able to keep up with players spamming seeds which every single test player has done

    public List<GameObject> worldItemList = new List<GameObject>(); // list of gameobjects to store seeds in world
    private int seedMx; // maximum seeds of type allowed in world
    private int ID; // Seed ID#
    private GameObject tarItem; // item that will be destroyed
    public bool cleanup; // bool to enable/disable seed grab while the destroy code is still running

    public void Start()
    {
        //reference the SeedPackageSetup script and copy the variables
        ID = GetComponent<SeedPackageSetup>().itemID;
        seedMx = GetComponent<SeedPackageSetup>().seedMax;

        cleanup = false; // not in destroy code at start

    }
    public void UpdateList() // method to update the list of game objects in the world
    {
        worldItemList.Clear(); // delete the current set of objects in the list

        // create a list of current seeds of this type in the world
        // this list is created by looking at the game objects in the Hierarchy from top to bottom
        // items are spawned top to bottom, so the first object it encounters will be the oldest object
        foreach (GameObject seedObj in GameObject.FindGameObjectsWithTag("seed")) // for every object that has the tag "seed"
        {
            if (seedObj.GetComponent<SeedPackageSetup>().itemID == ID) // check if that object's item ID is the same as this object's ID
            {
                worldItemList.Add(seedObj); // if it is the same ID, add to the list
            }
        }
    }
    public void ItemDestroy() // method to destroy excess seeds in the world
    {
        while (worldItemList.Count > seedMx) // so long as there are more seeds in the world than the max allowed by the seed's Max variable, run the following:
        {
            cleanup = true; // change bool to true so that the onGrab function in SeedPackageSetup.cs does not run (prevents spam)
            UpdateList(); // update the list of seeds currently in the world
            tarItem = worldItemList[0]; // set tarItem variable to the oldest instance of the seed
            Destroy(tarItem); // delete the oldest seed object.
        }
        if (worldItemList.Count <= seedMx) // once the while script is finished, set cleanup to false (I THINK this works..)
            cleanup = false;
    }
    public void Update() // test the update list by pressing space
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UpdateList();
        }
    }
}
