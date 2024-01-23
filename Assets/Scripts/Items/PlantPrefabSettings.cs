using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPrefabSettings : MonoBehaviour
{
    public List<GameObject> harvestable;
    public void RemoveFromList(GameObject obj)
    {
        harvestable.Remove(obj);
    }
}
