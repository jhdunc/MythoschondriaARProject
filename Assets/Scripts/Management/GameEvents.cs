using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }
    public event Action onSoilUpdate;
    public event Action<int> onSoilDry;
    public event Action onWatered;

    public event Action onTimeSkip;
    public void SoilDry(int id)
    {
        if (onSoilDry != null)
        {
            onSoilDry(id);
        }
    }
    public void SoilUpdate()
    {
        if (onSoilUpdate != null)
        {
            onSoilUpdate();
        }
    }

    public void TimeSkip()
    {
        if (onTimeSkip != null)
        {
            onTimeSkip();
        }
    }

    public void Watered()
    {
        if (onWatered != null)
            onWatered();
    }
}
