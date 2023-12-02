using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SeedPackageSetup : MonoBehaviour
{
    private XRInteractionManager interactionManager;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        interactionManager = GameObject.Find("XR Interaction Manager").GetComponent<XRInteractionManager>();
        GetComponentInChildren<XRGrabInteractable>().interactionManager = interactionManager;

        rb.isKinematic = true;
        rb.useGravity = false;
    }

    public void onGrab()
    {
        rb.isKinematic = false;
        rb.useGravity = true;        
    }

}
