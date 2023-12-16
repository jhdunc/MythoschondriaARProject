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
        currentPlot = plot;
        Debug.Log("Seeded State Entered!");
        if (plot.GetComponent<PlotScript>() != null)
        {
            GameObject instanceObject = GameObject.Instantiate(plot.GetComponent<PlotScript>().growthStages[0], plot.GetComponent<PlotSpawn>().signSpawn.transform.position, plot.GetComponent<PlotSpawn>().signSpawn.transform.rotation);
        }
        GameEvents.current.onTimeSkip += TimeSkip;
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

                saveItemID = otherObj.GetComponent<ToolScript>().itemID;
                switch (saveItemID)
                {
                    case 100:
                        plot.GetComponent<PlotScript>().ready = true;
                        ready = true;
                        plot.GetComponent<PlotScript>().growthStages = new List<GameObject>();
                        break;
                    case 101:
                        plot.GetComponent<PlotScript>().ready = true;
                        ready = true;
                        plot.GetComponent<PlotScript>().growthStages = new List<GameObject>();
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

    // Execute this code when button pressed (Time Advance)
    public override void OnTimerCall(PlotStateManager plot)
    {
        Debug.Log("pushed button");
        if (watered)
        {

        }
    }
#endregion

    // Event for Time Advance Button
    public void TimeSkip()
    {
        OnTimerCall(currentPlot);
    }

}
