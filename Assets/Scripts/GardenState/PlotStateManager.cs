using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotStateManager : MonoBehaviour
{
    public PlotBaseState currentState;
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

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    
}
