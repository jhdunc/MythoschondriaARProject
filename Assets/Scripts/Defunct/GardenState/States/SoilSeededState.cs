using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilSeededState : PlotBaseState
{
    // Variables to check plot status and assign plot to non-override code
    public bool watered;
    public bool ready;
    public PlotStateManager currentPlot;

    #region Override States (Things that Do Stuff)
    public override void EnterState(PlotStateManager plot)
    {
        Debug.Log("Seeded State Entered!");
        currentPlot = plot;
        GameEvents.current.SoilUpdate();
        GameEvents.current.onTimeSkip += TimeSkip;

        

        if (plot.GetComponent<PlotScript>() != null)
        {
            
            GameObject instanceObject = GameObject.Instantiate(plot.GetComponent<PlotScript>().growthStages[0], plot.GetComponent<PlotSpawn>().signSpawn.transform, worldPositionStays:false) ;
        }
    }
    public override void UpdateState(PlotStateManager plot)
    {

    }
    public override void OnCollisionEnter(PlotStateManager plot, Collision collision)
    {

    }
    public override void OnTriggerEnter(PlotStateManager plot, Collider other)
    {
        if (other.gameObject.tag == "seed" || other.gameObject.tag == "Tool")
        {
            GameObject otherObj = other.gameObject;
            int saveItemID;

            if (otherObj.CompareTag("Tool"))
            {
                // Tell the Plot what tool is being used

                saveItemID = otherObj.GetComponent<ToolScript>().itemInfo.itemID;
                switch (saveItemID)
                {
                    case 100:
                        plot.GetComponent<PlotScript>().ready = true;
                        ready = true;
                        plot.GetComponent<PlotScript>().growthStages = new List<GameObject>();
                        plot.SwitchState(plot.EmptyState);
                        break;
                    case 101:
                        plot.GetComponent<PlotScript>().ready = true;
                        ready = true;
                        plot.GetComponent<PlotScript>().growthStages = new List<GameObject>();
                        plot.SwitchState(plot.EmptyState);
                        break;
                    case 102:
                        plot.GetComponent<PlotScript>().watered = true;
                        watered = true;
                        break;
                }
                GameEvents.current.SoilUpdate();
            }
        }
    }

    public override void OnSelectXR(PlotStateManager plot)
    {

    }

    
    public override void OnTimerCall(PlotStateManager plot)
    {
        // Execute this code when button pressed (Time Advance)
        // General Function Flow:
        // Get the Plant's game object information
        // Destroy the plant
        // reset plot and move to next State
        
        if (plot.currentState.ToString() == "SoilSeededState")
        {
            Debug.Log(plot + " button seed");
            if (watered)
            {
                
                // Get name of growth stage 
                string y = plot.GetComponent<PlotScript>().growthStages[0].name;

                // set x variable to the plant's game object
                Transform x = plot.transform.Find($"SpawnPoints/SeedSign/{y}(Clone)");
                Debug.Log(y);
                Object.Destroy(x.gameObject);

                plot.GetComponent<PlotScript>().watered = false;
                plot.SwitchState(plot.SproutState);

            }
        }
        else { Debug.Log(plot + " button seed: else"); }
    }
    #endregion

    // Event for Time Advance Button
    public void TimeSkip()
    {
        OnTimerCall(currentPlot);
    }

}
