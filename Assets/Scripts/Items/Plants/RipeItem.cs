using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script attaches to the prefab vegetables that are ready to harvest.

public class RipeItem : MonoBehaviour
{
    [SerializeField] ItemDictionaries inventory;
    [SerializeField] ItemClass itemInfo;
    [SerializeField] GrabSetup setup;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<ItemDictionaries>(); // find the inventory 
        setup = GetComponent<GrabSetup>();
    }
    public void AddToInventory() // add to XR Grab Interactable event Select Entered.
    {
        if(setup.unGrabbed == true)
        inventory.AddToGardenList(itemInfo, 1);
    }

}
