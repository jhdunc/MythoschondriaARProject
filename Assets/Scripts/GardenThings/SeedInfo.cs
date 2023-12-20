using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class SeedInfo : ItemClass
{

    private XRInteractionManager interactionManager;
    public int seedMax;
    public Rigidbody rb;
    private SeedTracking seedWorld;
    private GameObject seedPacks;
    private GameObject seedSpawn;

    public GameObject plantPrefab;

    void Start()
    {
        if (seedMax == 0)
        { seedMax = 3; }

        rb = GetComponent<Rigidbody>();
        interactionManager = GameObject.Find("XR Interaction Manager").GetComponent<XRInteractionManager>();
        GetComponent<XRGrabInteractable>().interactionManager = interactionManager;
        seedPacks = GameObject.Find("SeedManager").GetComponent<SeedPacketGrid>().itemList[itemID];
        seedSpawn = GameObject.Find("SeedManager").GetComponent<SeedPacketGrid>().spawnPoint[itemID];

        seedWorld = GetComponent<SeedTracking>();

        rb.useGravity = true;
        rb.isKinematic = false;

    }

    public void OnGrab()
    {
        Debug.Log("grabbed it!");
        rb.constraints = RigidbodyConstraints.None;
        NewSeed();
        seedWorld.ItemDestroy();

    }

    public void NewSeed()
    {
        GameObject instanceObject = GameObject.Instantiate(seedPacks, seedSpawn.transform.position, seedSpawn.transform.rotation);
    }
}
