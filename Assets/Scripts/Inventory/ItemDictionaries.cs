using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDictionaries : MonoBehaviour
{
    public Dictionary<ItemClass, int> gardenInventory; // items that have been gathered and are in player's inventory
    public Dictionary<ItemClass, int> kitchenInventory; // items that have been sent to the kitchen
    public ItemClass[] item; // all of the items in the game, essentially a database
    private void Awake()
    {
        // initialize the inventories
        gardenInventory = new Dictionary<ItemClass, int>(); 
        kitchenInventory = new Dictionary<ItemClass, int>();

        for (int i = 0; i < item.Length; i++) // populate the inventories with the database
        {
            gardenInventory.Add(item[i], 0);
            kitchenInventory.Add(item[i], 0);
        }
    }

    public void AddToGardenList(ItemClass item, int quantity) // method to call when adding idems to the inventory. This is used in RipeItem.cs for harvesting.
    {
        gardenInventory[item] += quantity;
    }
    public void RemoveFromGardenList(ItemClass item, int quantity) // remove items from inventory
    {
        //should add in a safety check to make sure that it won't go negative
        gardenInventory[item] -= quantity;
    }
    public void AddToKitchenList(ItemClass item, int quantity)
    {
        RemoveFromGardenList(item, quantity);
        kitchenInventory[item] += quantity;
    }
}

