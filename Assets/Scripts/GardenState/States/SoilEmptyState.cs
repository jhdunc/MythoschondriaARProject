using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilEmptyState : PlotBaseState
{
    public bool watered;
    public bool ready;
    public bool seeded;
    public override void EnterState(PlotStateManager plot)
    {
        watered = plot.GetComponent<PlantScript>().watered;
        ready = plot.GetComponent<PlantScript>().ready;
        Debug.Log("State: EmptyState (no plant!)");
        // Code goes here for anything that happens when the plant is removed
        // or when the game starts. UI popup maybe?
    }
    public override void UpdateState(PlotStateManager plot)
    {

        if (ready && watered && seeded)
        {
            Debug.Log("ready!");
            plot.SwitchState(plot.SeededState); }


        
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
                        plot.GetComponent<PlantScript>().ready = true;
                        ready = true;
                        plot.GetComponent<PlantScript>().growthStages = new List<GameObject>();
                        break;
                    case 101:
                        plot.GetComponent<PlantScript>().ready = true;
                        ready = true;
                        plot.GetComponent<PlantScript>().growthStages = new List<GameObject>();
                        break;
                    case 102:
                        plot.GetComponent<PlantScript>().watered = true;
                        watered = true;
                        break;
                }
                GameEvents.current.SoilUpdate();


            }
            if (otherObj.CompareTag("seed"))
            {
                // Tell the Plot what seed is being planted
                if (!seeded)
                {
                    if (ready)
                    {
                        Debug.Log(otherObj);
                        plot.GetComponent<PlantScript>().growthStages.Clear();
                        plot.GetComponent<PlantScript>().growthStages.AddRange(otherObj.GetComponent<SeedPackageSetup>().growthStages);
                        Object.Destroy(otherObj);
                        plot.GetComponent<PlantScript>().seeded = true;
                        seeded = true;
                    }
                }


            }
        }

        

    }
    public override void OnSelectXR(PlotStateManager plot)
    {

    }
}
