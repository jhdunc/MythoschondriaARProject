using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Inventory System / Item")]
public class ItemClass : ScriptableObject
{
    // data/variables that EVERY item will have
    // adding variables here will add that variable to all scriptable objects
    public string itemName;
    public int itemID;
    public Image icon;
    
}