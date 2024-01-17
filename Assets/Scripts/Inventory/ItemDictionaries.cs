using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDictionaries : MonoBehaviour
{
    public Dictionary<ItemClass, int> gardenInventory;
    public Dictionary<ItemClass, int> kitchenInventory;
    public ItemClass[] item;
    private void Awake()
    {
        gardenInventory = new Dictionary<ItemClass, int>();
        kitchenInventory = new Dictionary<ItemClass, int>();

        for (int i = 0; i < item.Length; i++)
        {
            gardenInventory.Add(item[i], 0);
            kitchenInventory.Add(item[i], 0);
        }
/*        foreach (KeyValuePair<ItemClass, int> items in gardenInventory)
        {
            print("You have " + items.Value + " " + items.Key);

        }*/

    }

    public void AddToGardenList(ItemClass item, int quantity)
    {
        gardenInventory[item] += quantity;
    }
    public void RemoveFromGardenList(ItemClass item, int quantity)
    {
        gardenInventory[item] -= quantity;
    }
    public void AddToKitchenList(ItemClass item, int quantity)
    {
        gardenInventory[item] -= quantity;
        kitchenInventory[item] += quantity;
    }
}

