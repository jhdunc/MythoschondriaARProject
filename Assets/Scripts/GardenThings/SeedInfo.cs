using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class SeedInfo : ItemClass // Inherit from ItemClass (this gives it a name, itemID, etc in the inspector)
{
    private XRInteractionManager interactionManager; // set the interaction manager for VR interactions
    public int seedMax; // set the maximum number of seeds that can spawn in the world
    public Rigidbody rb; // variable to hold the object's rigidbody information
    private SeedTracking seedTrack;  // be able to set as specific instance of script on an object
    private GameObject seedPacks; // gameobject for the seedpackage
    private GameObject seedSpawn; // spawnpoint location held in an empty gameobject

    public GameObject plantPrefab; // the prefab in the Assets folders that holds all instances of plant growth

    void Start()
    {
        // on start, set default maximum seeds in world to 3 if no other limit is set
        if (seedMax == 0)
        { seedMax = 3; }

        rb = GetComponent<Rigidbody>(); // set the rb variable to this object's rigidbody
        
        // SETUP VR INTERACTION THINGS
        interactionManager = GameObject.Find("XR Interaction Manager").GetComponent<XRInteractionManager>(); // find the XR Interaction Manager and set variable to it
        GetComponent<XRGrabInteractable>().interactionManager = interactionManager; // Set the XR Grab script's interaction manager script to the variable found above
        
        // SETUP SPAWNING AND TRACKING
        seedPacks = GameObject.Find("SeedManager").GetComponent<SeedPacketGrid>().itemList[itemID]; // get object from list in the Grid
        seedSpawn = GameObject.Find("SeedManager").GetComponent<SeedPacketGrid>().spawnPoint[itemID]; // get object spawn point from list in the Grid
        seedTrack = GetComponent<SeedTracking>(); // get script from this object to reference as a variable

        rb.useGravity = true; // set gravity to true
        rb.constraints = RigidbodyConstraints.FreezeAll; // set all constraints to freeze (position/rotation) so that objects will not move on spawn
        rb.isKinematic = false; // object will move even if not acted upon (if not frozen)
        

    }

    public void OnGrab() // when grab used in VR controllers
    {
        if (seedTrack.cleanup == false) // make sure that the game is not currently running a cleanup cycle for seeds
        {
            seedTrack.UpdateList();
            Debug.Log("grabbed it!");
            rb.constraints = RigidbodyConstraints.None; // allow object movement
            seedTrack.ItemDestroy(); // run ItemDestroy() from SeedTracking.cs
            NewSeed(); // create new seed
        }
        else
        {
            // UNFINISHED
            // input "can't grab" message/function/etc
        }
    }

    public void NewSeed() // create new instance of seed at seed's spawn location
    {
        GameObject instanceObject = GameObject.Instantiate(seedPacks, seedSpawn.transform.position, seedSpawn.transform.rotation);
    }
}
