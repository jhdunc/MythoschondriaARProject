using UnityEngine;

public abstract class PlotBaseState
{
    public abstract void EnterState(PlotStateManager plot);
    public abstract void UpdateState(PlotStateManager plot);
    public abstract void OnCollisionEnter(PlotStateManager plot);
    public abstract void OnSelectXR(PlotStateManager plot);

}
