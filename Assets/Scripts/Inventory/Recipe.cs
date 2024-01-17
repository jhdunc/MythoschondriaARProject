using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InventorySystem/Recipe")]
public class Recipe : ScriptableObject
{
    [Header("Crafting Recipe")]
    public string recipeName;
    public List<ItemClass> ingredient;
    public List<int> quantity;


}

