using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plant growth states as an enum list
enum GrowthState
{
    Seeded, Sprout, Growing, Harvest
}

public class PlantScript : MonoBehaviour
{
    
    private GrowthState currentState; // variable to hold information on plant's current state (from the enum list)

    // GameObject variables to hold the model for each growth state
    public GameObject seeded;
    public GameObject sprout;
    public GameObject growing;
    public GameObject harvest;

    public float growTime; // how long it takes this plant to grow per state

    private bool growthActive = false; // read whether or not the plant is currently growing, default false
    void ChangeState(GrowthState newState) // a method to call when changing the plant's state. When called, will use one of the enum list things as the newState
    {
        currentState = newState; // set current state to the paramater used to call the method
        switch (currentState) // use switch cases to determine behavior based on state.
        {
            // each case sets the previous state as inactive and the new state as active
            // it does this by comparing the case against the parameter newState
            case GrowthState.Seeded: 
                seeded.SetActive(true);
                growthActive = false;
                break;
            case GrowthState.Sprout:
                seeded.SetActive(false);
                sprout.SetActive(true);
                growthActive = false;
                break;
            case GrowthState.Growing:
                sprout.SetActive(false);
                growing.SetActive(true);
                growthActive = false;
                break;
            case GrowthState.Harvest:
                growing.SetActive(false);
                harvest.SetActive(true);
                growthActive = false;
                break;
            default:
                break;
        }
    }
    void Start()
    {
        ChangeState(GrowthState.Seeded); // when instantiated, change growth state to Seeded
        GameEvents.current.onWatered += Watered; // still deciding on whether or not to use events for watering

        // check to make sure a grow time is set in the inspector
        // if no grow time is set, default is 30
        if (growTime == 0)
            growTime = 30f;

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

            // if the colliding object's tag is Tool
            if (otherObj.CompareTag("Tool"))
            {
                // Tell the Plot what tool is being used
                // by setting the local variable saveItemID to the colliding object's ID#

                saveItemID = otherObj.GetComponent<ToolScript>().itemID;

                // use switch cases to determine what happens based on that tool's item ID
                switch (saveItemID)
                {
                    case 100: // if item is a Hoe:
                        Debug.Log("Hoe has been used"); // debug to confirm Hoe recognition working
                        Destroy(gameObject); // destroy this game object 
                        break;
                    case 101: // if item is a Trowel:
                        Debug.Log("Trowel has been used"); // debug to confirm Trowel recognition working
                        Destroy(gameObject); // destroy this game object
                        break;
                    case 102:
                        Debug.Log("Water has been used"); // debug to confirm Watering Can recognition working
                        if (!growthActive) // if the plant is not currently growing, then start growing.
                            StartCoroutine(GrowthCycle()); // start coroutine that will change the growth state
                        break;
                }

            }
        }
    }


    private IEnumerator GrowthCycle() // a coroutine to start the growth period for the plant
    {
        growthActive = true; // set bool to indicate plant is now growing
            yield return new WaitForSeconds(growTime); // wait a number of seconds equal to the variable growTime

        // once timer has elapsed, check current state and advance to the next state.
            if (currentState == GrowthState.Seeded)
                ChangeState(GrowthState.Sprout);
            else if (currentState == GrowthState.Sprout)
                ChangeState(GrowthState.Growing);
            else if (currentState == GrowthState.Growing)
            { ChangeState(GrowthState.Harvest); }
            
    }
    public void Watered()
    {
        // watered event?
    }
    public void Tilled()
    {
        // tilled event?
    }
}