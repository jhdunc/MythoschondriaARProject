using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilSeededState : PlotBaseState
{
    public override void EnterState(PlotStateManager plot)
    {
        Debug.Log("Seeded State Entered!");
        GameObject instanceObject = GameObject.Instantiate(plot.GetComponent<PlantScript>().growthStages[0], plot.transform.position, plot.transform.rotation);
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
}
