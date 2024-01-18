using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InventorySystem/Recipe")]
public class Recipe : ScriptableObject
{
    [Header("Recipe")]
    public string recipeName; // name of the dish that will display at the top of the UI
    public List<ItemClass> ingredient; // the scriptable objects that will be used in the recipe
    public List<int> quantity; // the amount of each ingredient needed

}

