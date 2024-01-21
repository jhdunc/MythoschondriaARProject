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
    public bool unGrabbed;
    public GameObject parent;


    void Start()
    {
        unGrabbed = true;
        rb = GetComponent<Rigidbody>();
        interactionManager = GameObject.Find("XR Interaction Manager").GetComponent<XRInteractionManager>();
        GetComponent<XRGrabInteractable>().interactionManager = interactionManager;

        rb.useGravity = true;
        rb.isKinematic = false;
        grabbedScale = new Vector3(grabSize, grabSize, grabSize);
    }
    public void OnGrab()
    {
        RipeItem invScr = GetComponent<RipeItem>();
        

        if (unGrabbed == true)
        { 
            invScr.AddToInventory(); 
            unGrabbed = false; 
        }
        Debug.Log("i've been grabbed! says the tomato");
        rb.constraints = RigidbodyConstraints.None;

        parent.GetComponent<PlantPrefabSettings>().harvestable.Remove(gameObject);

        /*var vegToScale = GameObject.Find("Mesh").transform;*/
        var vegToScale = this.gameObject.transform.GetChild(0);
        vegToScale.transform.localScale = grabbedScale;

        DropObject();
        Debug.Log("RanDrop!");

    }

    private IEnumerator DropObject()
    {
        var grabCode = GetComponent<XRGrabInteractable>();
        yield return new WaitForSeconds(2);
        grabCode.enabled = false;
        grabCode.enabled = true;
        DestroyHeld();
        if (parent.GetComponent<PlantPrefabSettings>().harvestable.Count == 0)
        { GameObject.Destroy(parent); }
    }

    private void DestroyHeld()
    {
        Destroy(gameObject);
        
    }

}
