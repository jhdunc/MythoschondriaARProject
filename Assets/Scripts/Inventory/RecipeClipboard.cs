using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeClipboard : MonoBehaviour
{
    public GameObject clipboard;
    [SerializeField] ItemDictionaries inventory;
    [SerializeField] Recipe recipe;
    [SerializeField] TextMeshProUGUI recipeTitle;
    [SerializeField] GameObject recipePrefab;
    
    public GameObject gridParent;
    public Button kitchenButton;
    Dictionary<ItemClass,int> garInv;

    private void Start()
    {
        kitchenButton.interactable = false;
        garInv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<ItemDictionaries>().gardenInventory;

        recipeTitle.GetComponent<TextMeshProUGUI>().text = recipe.recipeName;


        for (int i = 0; i < recipe.ingredient.Count; i++)
        {
            var ingredient = recipe.ingredient[i];
            
            GameObject newPrefab;
            newPrefab = Instantiate(recipePrefab, gridParent.transform.position, gridParent.transform.rotation);
            newPrefab.transform.SetParent(gridParent.transform, false);
            newPrefab.name = $"Ingredient{i}";

            gridParent.transform.Find($"Ingredient{i}/TextName").GetComponent<TextMeshProUGUI>().text = ingredient.itemName;
            gridParent.transform.Find($"Ingredient{i}/ItemNeeded").GetComponent<TextMeshProUGUI>().text = recipe.quantity[i].ToString();


        }

    }
    private void Update()
    {
        for (int i = 0; i < recipe.ingredient.Count; i++)
        {
            foreach (var item in garInv)
            {
                if (item.Key == recipe.ingredient[i])
                    gridParent.transform.Find($"Ingredient{i}/ItemCount").GetComponent<TextMeshProUGUI>().text = item.Value.ToString();
                    
            }
        }

    }
    private void CheckRecipe()
    {
        
        for (int i = 0; i < recipe.ingredient.Count; i++)
        {
            bool keepChecking = true;
            foreach (var item in garInv)
            {
                if (item.Key == recipe.ingredient[i] && keepChecking == true)
                {
                    if(item.Value >= recipe.quantity[i])
                       keepChecking = true;
                    else
                        keepChecking = false;
                }
            }
            if(keepChecking == false)
            {
                kitchenButton.interactable = false;
            }
            else
                kitchenButton.interactable = true;
        }
    }

    public void SendToKitchen()
    {
        var item = recipe.ingredient;
        var qty = recipe.quantity;
        for (int i = 0; i < recipe.ingredient.Count; i++)
        {
            inventory.AddToKitchenList(item[i], qty[i]);
        }
        CheckRecipe();
    }
}
