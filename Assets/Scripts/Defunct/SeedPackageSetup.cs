using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SeedPackageSetup : ItemClass
{
    private XRInteractionManager interactionManager;
    public int seedMax;
    public Rigidbody rb;
    private SeedWorldScript seedWorld;
    private GameObject seedPacks;
    private GameObject seedSpawn;

    public List<GameObject> growthStages = new List<GameObject>();

    void Start()
    {
        if(seedMax == 0)
        { seedMax = 3; }

        rb = GetComponent<Rigidbody>();
        interactionManager = GameObject.Find("XR Interaction Manager").GetComponent<XRInteractionManager>();
        GetComponent<XRGrabInteractable>().interactionManager = interactionManager;
        seedPacks = GameObject.Find("SeedManager").GetComponent<SeedPacketGrid>().itemList[itemID];
        seedSpawn = GameObject.Find("SeedManager").GetComponent<SeedPacketGrid>().spawnPoint[itemID];

        seedWorld = GetComponent<SeedWorldScript>();

        rb.useGravity = true;
        rb.isKinematic = false;

    }

    public void OnGrab()
    {
        if (seedWorld.cleanup == false)
        {
            Debug.Log("grabbed it!");
            rb.constraints = RigidbodyConstraints.None;
            seedWorld.ItemDestroy();
            NewSeed();
        }
        else
        {
            // UNFINISHED
            // input "can't grab" message/function/etc
        }

    }

    public void NewSeed()
    {
        GameObject instanceObject = GameObject.Instantiate(seedPacks, seedSpawn.transform.position, seedSpawn.transform.rotation);
    }

}
