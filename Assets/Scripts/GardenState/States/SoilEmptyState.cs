using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilEmptyState : PlotBaseState
{
    public override void EnterState(PlotStateManager plot)
    {
        Debug.Log("State: EmptyState (no plant!)");
        // Code goes here for anything that happens when the plant is removed
        // or when the game starts. UI popup maybe?
    }
    public override void UpdateState(PlotStateManager plot)
    {
        // WHEN READY TO GO
        // 
        plot.SwitchState(plot.SeededState);
    }
    public override void OnCollisionEnter(PlotStateManager plot)
    {

    }
    public override void OnSelectXR(PlotStateManager plot)
    {

    }
}
