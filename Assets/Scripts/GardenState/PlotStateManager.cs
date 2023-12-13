using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotStateManager : MonoBehaviour
{
    PlotBaseState currentState;
    public SoilEmptyState EmptyState = new SoilEmptyState();
    public SoilSeededState SeededState = new SoilSeededState();
    public SoilSproutState SproutState = new SoilSproutState();
    public SoilGrowingState GrowingState = new SoilGrowingState();
    public SoilMultiState MultiState = new SoilMultiState();
    public SoilHarvestState HarvestState = new SoilHarvestState();
    void Start()
    {
        currentState = EmptyState;

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
