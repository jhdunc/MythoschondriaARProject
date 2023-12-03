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

    
    void Start()
    {
        if(seedMax == 0)
        { seedMax = 2; }



        rb = GetComponentInChildren<Rigidbody>();
        interactionManager = GameObject.Find("XR Interaction Manager").GetComponent<XRInteractionManager>();
        GetComponentInChildren<XRGrabInteractable>().interactionManager = interactionManager;

        rb.isKinematic = true;
        rb.useGravity = false;
    }

    public void OnGrab()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        seedWorld.UpdateList();
    }




}
