using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoilScript : MonoBehaviour
{
    public static int[] seedPlacement = new int[12];//Add what seed(ID) had been planted where(ID) on an array
    public static object[] plantPlacement = new object[12];//Add what plant(instance as child) had been planted where(ID) on an array

    public int id; // set in inspector - specific to plot

    // game objects for tilled vs not tilled ground so that the object switches when tool used.
    public GameObject enterState;
    public GameObject tilledState;

    // colors for whether or not the ground/plant has been watered, set in the inspector.
    public Color dryColor;
    public Color wetColor;

    // bools to control whether or not actions can be taken based on current plot state
    private bool tilled;
    private bool plotFull;


    //On instantiate plant as child
    //Locate child, put in list
    //plantPlacement.SetValue(savePlantItemID,id);


    private void Start()
    {

        // subscribe to EVENT: SoilDry
        GameEvents.current.onSoilDry += SoilDry;

        // when plot is created, set default state to untilled and make tilled inactive.
        enterState.SetActive(true);
        tilledState.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        // on a collision with the soil's trigger collision box, 
        // if the game object has the tag "seed" or "Tool" 
        if (other.gameObject.tag == "seed" || other.gameObject.tag == "Tool")
        {
            // set variable for the colliding object as a local variable
            // set up a local variable to hold the colliding item's ID# to identify what the tool is
            GameObject otherObj = other.gameObject;
            int saveItemID;
            int saveSeedItemID;

            // if the colliding object's tag is Tool
            if (otherObj.CompareTag("Tool"))
            {
                // Tell the Plot what tool is being used
                // by setting the local variable saveItemID to the colliding object's ID#

                saveItemID = otherObj.GetComponent<ToolScript>().itemInfo.itemID;

                // use switch cases to determine what happens based on that tool's item ID
                switch (saveItemID)
                {
                    case 100: // if item is a Hoe:
                        Debug.Log("Hoe has been used"); // debug to confirm Hoe recognition working
                        FindObjectOfType<AudioManager>().Play("Dig"); // digging SFX plays
                        SetTilled(); // change game object to tilled

                        tilled = true; // set bool to indicate the soil has been tilled
                        plotFull = false; // set bool to indicate there is no longer a plant here

                        // code to destroy plant is in PlantScript.cs
                        break;

                    case 101: // if item is a Trowel
                        Debug.Log("Trowel has been used"); // debug to confirm Trowel recognition working
                        FindObjectOfType<AudioManager>().Play("Dig"); //digging SFX plays
                        SetTilled();

                        tilled = true; // set bool to indicate the soil has been tilled
                        plotFull = false; // set bool to indicate there is no longer a plant here

                        // code to destroy plant is in PlantScript.cs
                        // case currently the same as HOE
                        break;

                    case 102: // if item is a Watering Can
                        Debug.Log("Water has been used"); // debug to confirm WateringCan recognition working
                        SoilWet(this.id); //  call method to make soil Wet
                        break;
                }

            }
            // if the colliding object's tag is "seed"
            if (otherObj.CompareTag("seed"))
            {
                saveSeedItemID = otherObj.GetComponent<SeedInfo>().itemInfo.itemID;//save what seed is being used

                // Tell the Plot what seed is being planted
                if (tilled == true && !plotFull) // check that the soil has been tilled and does not already have a plant growing
                {
                    FindObjectOfType<AudioManager>().Play("Pop"); // planted SFX plays
                    plotFull = true; // switch bool to indicate a plant is now growing in the soil
                    SetUntilled(); // change game object to untilled
                    
                    // create instance of the plant that the seed should grow
                    // code means: Make a Game Object(get the variable plantPrefab from SeedInfo attached to colliding object, make the object of this script the parent, set location relative to parent)
                    GameObject instanceObject = GameObject.Instantiate(otherObj.GetComponent<SeedInfo>().plantPrefab, gameObject.transform, worldPositionStays: false);

                    seedPlacement.SetValue(saveSeedItemID,id);//Add saved seed ID to an array at the spot of soil id

                    Destroy(otherObj); // destroy the seed GameObject
                    SoilDry(this.id);

                }
            }
        }
    }
    private void SoilDry(int id)
    {
        if (id == this.id)
        {
            enterState.GetComponent<Renderer>().material.color = dryColor; // change untilled soil to unwatered
            tilledState.GetComponent<Renderer>().material.color = dryColor; // change tilled soil to unwatered
        }
    }
    private void SoilWet(int id)
    {
        if (id == this.id)
        {
            enterState.GetComponent<Renderer>().material.color = wetColor; // change untilled soil to unwatered
            tilledState.GetComponent<Renderer>().material.color = wetColor; // change tilled soil to unwatered
        }
    }
    public void ResetPlot()
    {
        tilled = true; // set bool to indicate the soil has been tilled
        plotFull = false; // set bool to indicate there is no longer a plant here
        SoilDry(this.id);
    }

    private void SetTilled()
    {
        tilledState.SetActive(true); 
        enterState.SetActive(false);
    }
    private void SetUntilled()
    {
        enterState.SetActive(true);
        tilledState.SetActive(false);
    }
    private void OnDestroy()
    {
        // if this object is destroyed, unsubscribe from the event
        GameEvents.current.onSoilDry -= SoilDry;
    }
}
