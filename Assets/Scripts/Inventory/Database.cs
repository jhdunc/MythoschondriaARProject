using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System / Item Database")]
public class Database : ScriptableObject
{
    [SerializeField] private List<ItemClass> itemDatabase;
}
