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
    public bool firstGrab;
    public GameObject parent;


    void Start()
    {
        firstGrab = false;
        rb = GetComponent<Rigidbody>();
        interactionManager = GameObject.Find("XR Interaction Manager").GetComponent<XRInteractionManager>();
        GetComponent<XRGrabInteractable>().interactionManager = interactionManager;

        rb.useGravity = true;
        rb.isKinematic = false;
        grabbedScale = new Vector3(grabSize, grabSize, grabSize);
    }
    public void OnGrab()
    {
        if (firstGrab == false)
        { firstGrab = true; }
        Debug.Log("i've been grabbed! says the tomato");
        rb.constraints = RigidbodyConstraints.None;

        transform.SetParent(null);
        parent.GetComponent<PlantPrefabSettings>().RemoveFromList(gameObject);

        var vegToScale = GameObject.Find("Mesh").transform;
        Debug.Log("scale before: " + vegToScale.transform.localScale);
        vegToScale.transform.localScale = grabbedScale;
        Debug.Log("scale after: " + vegToScale.transform.localScale);
        DropObject();
    }

    private IEnumerator DropObject()
    {
        var grabCode = GetComponent<XRGrabInteractable>();
        yield return new WaitForSeconds(2);
        grabCode.enabled = false;
        grabCode.enabled = true;
        if(parent.GetComponent<PlantPrefabSettings>().harvestable.Count == 0)
            GameObject.Destroy(parent);
    }



}
