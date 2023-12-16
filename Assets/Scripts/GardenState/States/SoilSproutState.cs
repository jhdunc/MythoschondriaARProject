using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilSproutState : PlotBaseState
{
    public override void EnterState(PlotStateManager plot)
    {
        Debug.Log("entered Sprout state");
        if (plot.GetComponent<PlotScript>() != null)
        {
            // create game object of sprout from list growthStages
            GameObject instanceObject = GameObject.Instantiate(plot.GetComponent<PlotScript>().growthStages[1], plot.GetComponent<PlotSpawn>().sproutSpawn.transform.position, plot.GetComponent<PlotSpawn>().signSpawn.transform.rotation);
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

    }

}
