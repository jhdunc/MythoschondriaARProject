using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onSoilTill;

    public void SoilTill()
    {
        if(onSoilTill != null)
        {
            onSoilTill();
        }
    }
}
