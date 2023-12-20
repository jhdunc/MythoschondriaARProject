using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoilScript : MonoBehaviour
{
    public GameObject enterState;
    public GameObject tilledState;
    public GameObject plantSpawn;

    public Color dryColor;
    public Color wetColor;

    private bool tilled;
    private void Start()
    {
        enterState.SetActive(enabled);
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
                        enterState.SetActive(false);
                        tilledState.SetActive(true);
                        tilled = true;
                        break;
                    case 101:
                        Debug.Log("Trowel has been used");
                        enterState.SetActive(false);
                        tilledState.SetActive(true);
                        tilled = true;
                        break;
                    case 102:
                        Debug.Log("Water has been used");
                        enterState.GetComponent<Renderer>().material.color = wetColor;
                        tilledState.GetComponent<Renderer>().material.color = wetColor;
                        break;
                }

            }
            if (otherObj.CompareTag("seed"))
            {
                // Tell the Plot what seed is being planted
                if (tilled == true)
                {
                    GameObject instanceObject = GameObject.Instantiate(otherObj.GetComponent<SeedInfo>().plantPrefab, gameObject.transform, worldPositionStays: false);
                    Destroy(otherObj);
                    enterState.GetComponent<Renderer>().material.color = dryColor;
                    tilledState.GetComponent<Renderer>().material.color = dryColor;
                }
            }
        }
    }

}
