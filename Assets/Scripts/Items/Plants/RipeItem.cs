using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script attaches to the prefab vegetables that are ready to harvest.

public class RipeItem : MonoBehaviour
{
    [SerializeField] ItemDictionaries inventory;
    [SerializeField] ItemClass itemInfo;
    [SerializeField] GrabSetup setup;
    private Rigidbody rb;

    [SerializeField] GameObject poof;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<ItemDictionaries>(); // find the inventory 
        setup = GetComponent<GrabSetup>();
    }
    public void AddToInventory() // add to XR Grab Interactable event Select Entered.
    {
        if(setup.unGrabbed == true)
        inventory.AddToGardenList(itemInfo, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            StartCoroutine(MakePoof());
            Debug.Log("after poof?");
        }
    }

    public IEnumerator MakePoof()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject.transform.GetChild(0).gameObject);
        Vector3 xyz = new Vector3(0, 90, 0);
        Quaternion newRotation = Quaternion.Euler(xyz);
        
        GameObject thispoof;
        thispoof = Instantiate(poof, this.transform.position, newRotation);
        thispoof.transform.SetParent(this.transform, false);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}
