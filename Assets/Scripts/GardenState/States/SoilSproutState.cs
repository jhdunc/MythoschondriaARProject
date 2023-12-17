using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilSproutState : PlotBaseState
{
    // Variables to check plot status and assign plot to non-override code
    public bool watered;
    public bool ready;
    public PlotStateManager currentPlot;
    public override void EnterState(PlotStateManager plot)
    {
        Debug.Log("Sprout Entered!");

        currentPlot = plot;
        GameEvents.current.SoilUpdate();
        GameEvents.current.onTimeSkip += TimeSkip;

        if (plot.GetComponent<PlotScript>() != null)
        {
            GameObject instanceObject = GameObject.Instantiate(plot.GetComponent<PlotScript>().growthStages[1], plot.GetComponent<PlotSpawn>().sproutSpawn.transform, worldPositionStays: false);
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
        Debug.Log("pushed button");
        if (watered)
        {

        }
    }
    // Event for Time Advance Button
    public void TimeSkip()
    {
        OnTimerCall(currentPlot);
    }
}
