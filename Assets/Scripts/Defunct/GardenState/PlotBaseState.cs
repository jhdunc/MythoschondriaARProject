using UnityEngine;

public abstract class PlotBaseState 
{
    public abstract void EnterState(PlotStateManager plot);
    public abstract void UpdateState(PlotStateManager plot);
    public abstract void OnCollisionEnter(PlotStateManager plot, Collision collision);
    public abstract void OnTriggerEnter(PlotStateManager plot, Collider other);
    public abstract void OnSelectXR(PlotStateManager plot);
    public abstract void OnTimerCall(PlotStateManager plot);

}
