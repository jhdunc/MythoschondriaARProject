using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilHarvestState : PlotBaseState
{
    // Variables to check plot status and assign plot to non-override code
    public bool watered;
    public bool ready;
    public PlotStateManager currentPlot;
    public override void EnterState(PlotStateManager plot)
    {
        Debug.Log("Harvest state Entered!");

        currentPlot = plot;
        GameEvents.current.SoilUpdate();
        GameEvents.current.onTimeSkip += TimeSkip;

        if (plot.GetComponent<PlotScript>() != null)
        {
            GameObject instanceObject = GameObject.Instantiate(plot.GetComponent<PlotScript>().growthStages[4], plot.GetComponent<PlotSpawn>().harvestSpawn.transform, worldPositionStays: false);
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

    }

    public override void OnSelectXR(PlotStateManager plot)
    {

    }

    
    public override void OnTimerCall(PlotStateManager plot)
    {
        // Execute this code when button pressed (Time Advance)
        // This is harvest state, so it will not be used
    }


    // Event for Time Advance Button
    public void TimeSkip()
    {
        OnTimerCall(currentPlot);
    }

}
