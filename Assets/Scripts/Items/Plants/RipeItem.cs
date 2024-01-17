using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipeItem : MonoBehaviour
{
    [SerializeField] ItemDictionaries inventory;
    [SerializeField] ItemClass itemInfo;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<ItemDictionaries>();
    }
    public void AddToInventory()
    {
        inventory.AddToGardenList(itemInfo, 1);
    }

}
