using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// Added to harvest items to make sure they grab correctly
public class GrabSetup : MonoBehaviour
{
    private XRInteractionManager interactionManager;
    private Rigidbody rb;
    [SerializeField] float grabSize;
    private Vector3 grabbedScale;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        interactionManager = GameObject.Find("XR Interaction Manager").GetComponent<XRInteractionManager>();
        GetComponent<XRGrabInteractable>().interactionManager = interactionManager;

        rb.useGravity = true;
        rb.isKinematic = false;
        grabbedScale = new Vector3(grabSize, grabSize, grabSize);
    }
    public void OnGrab()
    {

        Debug.Log("i've been grabbed! says the tomato");
        rb.constraints = RigidbodyConstraints.None;
        transform.SetParent(null);

        // UP FOR GRABS
        // WHY IS THIS NO WORK
        Debug.Log("scale before: " + gameObject.transform.localScale);
        gameObject.transform.localScale = grabbedScale;
        Debug.Log("scale after: " + gameObject.transform.localScale);

    }


}
