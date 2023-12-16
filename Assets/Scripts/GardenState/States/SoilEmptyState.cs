using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilEmptyState : PlotBaseState
{
    public bool watered;
    public bool ready;
    public bool seeded;
    public GameObject stateList;

    public override void EnterState(PlotStateManager plot)
    {
        
        stateList = GameObject.Find("StateListManager");
        // Code goes here for anything that happens when the plant is removed
        // or when the game starts. UI popup maybe?

        // Check if GameObject contains the script for a Plot
        // Then set variable to same value as Plot script
        if (plot.GetComponent<PlotScript>() != null)
        {
            watered = plot.GetComponent<PlotScript>().watered;
            ready = plot.GetComponent<PlotScript>().ready;
        }
        
        // Setup State List prefab objects
        #region Setup State List prefab objects
        if (plot.gameObject.name == "PrefabEmptyState")
        {
            plot.SwitchState(plot.SproutState);
        }
        if (plot.gameObject.name == "PrefabSeededState")
        {
            plot.SwitchState(plot.SeededState);
        }
        if (plot.gameObject.name == "PrefabGrowingState")
        {
            plot.SwitchState(plot.GrowingState);
        }
        if (plot.gameObject.name == "PrefabMultiState")
        {
            plot.SwitchState(plot.MultiState);
        }
        if (plot.gameObject.name == "PrefabHarvestState")
        {
            plot.SwitchState(plot.HarvestState);
        }
        // bool: don't run the compilation of states in the Manager
        // until all states have been assigned
        stateList.GetComponent<StateList>().readState = true;

        #endregion
    }
    public override void UpdateState(PlotStateManager plot)
    {
        // if all 3 conditions met, remove condition "watered" and advance to next State
        // Does not adhere to timer, as this is not a growth stage
        if (ready && watered && seeded)
        {
            plot.GetComponent<PlotScript>().watered = false;
            plot.SwitchState(plot.SeededState); 
        }

    }
    public override void OnCollisionEnter(PlotStateManager plot, Collision collision)
    {

    }
    public override void OnTriggerEnter(PlotStateManager plot, Collider other)
    {
        // check if object entering trigger area is a seed or a tool
        if (other.gameObject.tag == "seed" || other.gameObject.tag == "Tool")
        { 
            // save colliding object to a variable
            
            GameObject otherObj = other.gameObject;
           
            // if player is holding a tool:
            if (otherObj.CompareTag("Tool"))
            {
                // set switch cases to tool ID numbers
                
                switch (otherObj.GetComponent<ToolScript>().itemID)
                {
                    case 100: // HOE
                        plot.GetComponent<PlotScript>().ready = true;
                        ready = true;
                        
                        // clear list of growth stages (saved seed information)
                        plot.GetComponent<PlotScript>().growthStages.Clear();
                        break;

                    case 101: // TROWEL
                        plot.GetComponent<PlotScript>().ready = true;
                        ready = true;
                        
                        // clear list of growth stages (saved seed information)
                        plot.GetComponent<PlotScript>().growthStages.Clear();
                        break;

                    case 102: // WATERING CAN
                        plot.GetComponent<PlotScript>().watered = true;
                        watered = true;
                        break;
                }
                // run game event for soil update script: checks variables and updates Soil image to match
                // in prototype: color of the greybox soil ball
                GameEvents.current.SoilUpdate();


            }
            if (otherObj.CompareTag("seed"))
            {
                // Tell the Plot what seed is being planted
                if (!seeded)
                {
                    if (ready)
                    {
                        plot.GetComponent<PlotScript>().growthStages.Clear();
                        plot.GetComponent<PlotScript>().growthStages.AddRange(otherObj.GetComponent<SeedPackageSetup>().growthStages);
                        
                        // Destroy Seed object
                        Object.Destroy(otherObj);

                        plot.GetComponent<PlotScript>().seeded = true;
                        seeded = true;
                    }
                }


            }
        }

    }
    public override void OnSelectXR(PlotStateManager plot)
    {

    }
    public override void OnTimerCall(PlotStateManager plot)
    {

    }
}
