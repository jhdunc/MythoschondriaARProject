using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a UI Manager for the clipboard
public class RecipeBoard : MonoBehaviour
{
    public GameObject[] recipe; // add the parent object of each recipe "page" to this array 
    private int currentRecipe; // track the current page

    void Start() 
    {
        // Hide all pages to make sure none were accidentally left active
        // then set the first page to active

        HideAllRecipes();
        recipe[0].SetActive(true);
        currentRecipe = 0;
    }

    public void HideAllRecipes() // a safety measure
    {
        for (int i = 0; i < recipe.Length; i++) // loop through the recipe pages and set them all to false
        {
            recipe[i].SetActive(false);
        }
    }    

    public void NextRecipe() // method to be called from UI button navigation
    {
        HideAllRecipes();
        if (currentRecipe < (recipe.Length -1)) // check recipe page against total number of recipes
        {
            currentRecipe += 1;
            recipe[currentRecipe].GetComponent<RecipeClipboard>().CheckRecipe();
            recipe[currentRecipe].SetActive(true);
        }
        else // if it is the last recipe page, reset to the first page
        {
            currentRecipe = 0;
            recipe[currentRecipe].SetActive(true);
        }    

    }

    public void LastRecipe() // method to be called from UI button navigation
    {
        HideAllRecipes();
        if (currentRecipe > 0) // verify that the current page is not the first page
        {
            currentRecipe -= 1;
            recipe[currentRecipe].SetActive(true);
        }
        else // if the current recipe is the first page in the list, go to the last page
        {
            currentRecipe = (recipe.Length - 1);
            recipe[currentRecipe].SetActive(true);
        }
    }
}
