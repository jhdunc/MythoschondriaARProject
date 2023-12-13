using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotStateManager : MonoBehaviour
{
    PlotBaseState currentState;
    public SoilUnreadyDryState UnreadyDryState = new SoilUnreadyDryState();
    public SoilUnreadyWetState UnreadyWetState = new SoilUnreadyWetState();
    public SoilReadyDryState ReadyDryState = new SoilReadyDryState();
    public SoilReadyWetState ReadyWetState = new SoilReadyWetState();

    public SoilSproutDryState SproutDryState = new SoilSproutDryState();
    public SoilSproutWetState SproutWetState = new SoilSproutWetState();

    public SoilPlantDryState PlantDryState = new SoilPlantDryState();
    public SoilPlantWetState PlantWetState = new SoilPlantWetState();

    public SoilHarvestState HarvestState = new SoilHarvestState();
    void Start()
    {
        currentState = UnreadyDryState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlotBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
