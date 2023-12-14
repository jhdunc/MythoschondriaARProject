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

    public event Action onSoilUpdate;
    public event Action onTimeSkip;
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
}
