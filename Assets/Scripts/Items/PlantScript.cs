using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GrowthState
{
    Seeded, Sprout, Growing, Harvest
}

public class PlantScript : MonoBehaviour
{
    private GrowthState currentState;//TODO: SAVE this
    public GameObject seeded;
    public GameObject sprout;
    public GameObject growing;
    public GameObject harvest;

    public float growTime;

    private bool watered = false;//TODO: SAVE this
    void ChangeState(GrowthState newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case GrowthState.Seeded:
                seeded.SetActive(true);
                break;
            case GrowthState.Sprout:
                seeded.SetActive(false);
                sprout.SetActive(true);
                break;
            case GrowthState.Growing:
                sprout.SetActive(false);
                growing.SetActive(true);
                break;
            case GrowthState.Harvest:
                growing.SetActive(false);
                harvest.SetActive(true);
                break;
            default:
                break;
        }
    }
    void Start()
    {
        ChangeState(GrowthState.Seeded);
        GameEvents.current.onWatered += Watered;
        if (growTime == 0)
            growTime = 30f;

    }

    private void OnTriggerEnter(Collider other)
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
                        Debug.Log("Hoe has been used");
                        Destroy(gameObject);
                        break;
                    case 101:
                        Debug.Log("Trowel has been used");
                        Destroy(gameObject);
                        break;
                    case 102:
                        Debug.Log("Water has been used");
                        watered = true;
                        StartCoroutine(GrowthCycle());
                        break;
                }

            }
        }
    }


    private IEnumerator GrowthCycle()
    {
        if (watered == true)
        {
            watered = false;
            yield return new WaitForSeconds(growTime);
            if (currentState == GrowthState.Seeded)
                ChangeState(GrowthState.Sprout);
            else if (currentState == GrowthState.Sprout)
                ChangeState(GrowthState.Growing);
            else if (currentState == GrowthState.Growing)
            { ChangeState(GrowthState.Harvest); }
            
        }

    }
    public void Watered()
    {
        // watered event?
    }
    public void Tilled()
    {
        // tilled event?
    }
}