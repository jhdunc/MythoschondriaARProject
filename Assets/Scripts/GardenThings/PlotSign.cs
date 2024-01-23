using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotSign : MonoBehaviour
{
    public ItemClass plantInfo;
    public Image iconPlant;
    public Sprite iconReady;
    private PlantScript parentScript;
    public void Start()
    {
        
        parentScript = GetComponentInParent<PlantScript>();
    }
    private void Update()
    {
        if (parentScript.currentState == GrowthState.Harvest)
            iconPlant.sprite = iconReady;
        else
            iconPlant.sprite = plantInfo.icon;
    }
}
