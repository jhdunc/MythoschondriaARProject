using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBoard : MonoBehaviour
{
    public GameObject[] recipe;
    private int currentRecipe;

    void Start()
    {
        HideAllRecipes();
        recipe[0].SetActive(true);
        currentRecipe = 0;
    }

    public void HideAllRecipes()
    {
        for (int i = 0; i < recipe.Length; i++)
        {
            recipe[i].SetActive(false);
        }
    }    

    public void NextRecipe()
    {
        HideAllRecipes();
        if (currentRecipe < (recipe.Length -1))
        {
            currentRecipe += 1;
            recipe[currentRecipe].SetActive(true);
        }
        else
        {
            currentRecipe = 0;
            recipe[currentRecipe].SetActive(true);
        }    

    }

    public void LastRecipe()
    {
        HideAllRecipes();
        if (currentRecipe > 0)
        {
            currentRecipe -= 1;
            recipe[currentRecipe].SetActive(true);
        }
        else
        {
            currentRecipe = (recipe.Length - 1);
            recipe[currentRecipe].SetActive(true);
        }
    }
}
