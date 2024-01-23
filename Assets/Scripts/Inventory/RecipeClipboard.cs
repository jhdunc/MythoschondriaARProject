using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// this script provides the functionality for a recipe page on the clipboard.
public class RecipeClipboard : MonoBehaviour
{
    [SerializeField] ItemDictionaries inventory; // the inventories for garden and kitchen
    [SerializeField] Recipe recipe; // the recipe for this page
    [SerializeField] TextMeshProUGUI recipeTitle; // the UI Text object that will display the Title
    [SerializeField] GameObject recipePrefab; // prefab that holds text objects for ingredient name, amount needed, and amount in inventory
    
    public GameObject gridParent; // tell the prefab where to instantiate
    public Button kitchenButton; // button to make stuff go away
    Dictionary<ItemClass,int> garInv; // reference to the garden inventory

    private void Start()
    {
        GameEvents.current.onCheckRecipe += CheckRecipe;

        kitchenButton.interactable = false; // cannot interact with the kitchen button. Also activates the "disabled" color tint.
        garInv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<ItemDictionaries>().gardenInventory; // set reference to inventory of veggies collected

        recipeTitle.GetComponent<TextMeshProUGUI>().text = recipe.recipeName; // get the name of the recipe from the scriptable object.


        for (int i = 0; i < recipe.ingredient.Count; i++) // loops through every ingredient in the recipe
        {
            var ingredient = recipe.ingredient[i]; // set variable to this specific ingredient within the loop
            
            // create the UI text field prefab for this specific ingredient
            GameObject newPrefab;
            Quaternion fabRot = new Quaternion(0, 0, 0, 0);
            newPrefab = Instantiate(recipePrefab, gridParent.transform.position, fabRot); // creates the recipePrefab with position and rotation of gridParent
            newPrefab.transform.SetParent(gridParent.transform, false); // sets the prefab to be a child of the gridParent - this makes it easier to find
            newPrefab.name = $"Ingredient{i}"; // rename the prefab to reference it's index number (ensures that each iteration is unique)

            gridParent.transform.Find($"Ingredient{i}/TextName").GetComponent<TextMeshProUGUI>().text = ingredient.itemName; // Find the prefab's text field for item name and change it to match the item name of this ingredient
            gridParent.transform.Find($"Ingredient{i}/ItemNeeded").GetComponent<TextMeshProUGUI>().text = recipe.quantity[i].ToString(); // Find the prefab's text field for Quantity needed, and update to match qty from the recipe (requires being turned into a string)
            
        }

    }
    private void Update()
    {
/*        if(Input.GetKeyDown(KeyCode.Space))
        { 
        CheckRecipe();
        }*/
        for (int i = 0; i < recipe.ingredient.Count; i++) // loop through the ingredient list
        {
            foreach (var item in garInv) // for every item in the garden inventory:
            {
                if (item.Key == recipe.ingredient[i]) // check if the key in the dictionary matches the ingredient in the list and update item amount if it does
                    gridParent.transform.Find($"Ingredient{i}/ItemCount").GetComponent<TextMeshProUGUI>().text = item.Value.ToString();
            }
        }

    }
    public void CheckRecipe()
    {
        int trueCount = 0;
        foreach (var veggie in inventory.gardenInventory) // so far so good
        {
            for (int i = 0; i < recipe.ingredient.Count; i++) // for every ingredient in the recipe list, still good
            {
                if (veggie.Key == recipe.ingredient[i]) // still good, checks Key (name in inventory) against ingredients in list
                {
                    if (veggie.Value >= recipe.quantity[i])
                    {
                        trueCount += 1;
                        if (trueCount == recipe.ingredient.Count)
                        { kitchenButton.interactable = true; }
                        else { kitchenButton.interactable = false; }
                    }
                }
            }
        }
    }

    public void SendToKitchen() // method to call via button
    {
        var item = recipe.ingredient; // local variable to make the loop below look neater
        var qty = recipe.quantity; // local variable to make the loop below look neater

        for (int i = 0; i < item.Count; i++) // loop through the ingredient list in the recipe
        {
            inventory.AddToKitchenList(item[i], qty[i]); // call method from ItemDictionaries.cs
        }
        CheckRecipe();
    }
    private void OnDestroy()
    {
        GameEvents.current.onCheckRecipe -= CheckRecipe;
    }
}
