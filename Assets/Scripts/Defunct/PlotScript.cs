using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlotScript : MonoBehaviour
{
    public bool ready;
    public bool watered;
    public bool seeded;
    public List<GameObject> growthStages = new List<GameObject>();

    [Header("Soil Status")]
    public GameObject dryUnready;
    public GameObject wetUnready;
    public GameObject dryReady;
    public GameObject wetReady;

    private void Start()
    {
        GameEvents.current.onSoilUpdate += SoilUpdate;
        GameEvents.current.onWatered += Watered;
    }

    #region TimeUpdate

    private void Watered()
    {

    }    

    #endregion
    #region SoilUpdates

    private void SoilUpdate()
    {
        if(ready && watered)
        {
            EnableWetTilled();
        }
        else if(ready && !watered)
        {
            EnableDryTilled();
        }
        else if(watered && !ready)
        {
            EnableWetUnready();
        }
    }
    
    void DisableAllSoil()
    {
        dryUnready.SetActive(false);
        wetUnready.SetActive(false);
        dryReady.SetActive(false);
        wetReady.SetActive(false);
    }

    void EnableDryTilled()
    {
        DisableAllSoil();
        dryReady.SetActive(true);
    }

    void EnableWetTilled()
    {
        DisableAllSoil();
        wetReady.SetActive(true);
    }

    void EnableWetUnready()
    {
        DisableAllSoil();
        wetUnready.SetActive(true);
    }
    void EnableDryUnready()
    {
        DisableAllSoil();
        dryUnready.SetActive(true);
    }
    #endregion
}
