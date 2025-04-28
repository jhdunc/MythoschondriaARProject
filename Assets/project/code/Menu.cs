using System;
using System.Collections.Generic;
using System.Text;
using ADG;
using insitu;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [NonSerialized] public float Alpha;

    public Canvas Canvas;
    public CanvasGroup Group;

    public void Update()
    {
        var enable_canvas = Alpha > 0.0001f;
        if (!enable_canvas)
            Canvas.enabled = false;

        var alpha = Ease.Hermite(Alpha);
        Group.alpha = alpha;
        Group.blocksRaycasts = alpha > 0.9999f;

        // EDIT ME //
        // If UI elements or game objects present,
        // the following increases/decreases scale, creating a zoom in/out 
        // on menu activation and de-activation 
        // change obj to a reference
        //
        // var scale = new Vector3(alpha, alpha, alpha);
        // obj.transform.localScale = scale;
        
        if (enable_canvas)
            Canvas.enabled = true;
    }
    public void UpdateActive(Main main, float deltaTime)
    {
        var app = main.App;
        if(!App.FetchState(app))
        {
            UpdateInactive(deltaTime);
            return;
        }

        Alpha += deltaTime / 0.6f;
        if (Alpha > 1.0f)
            Alpha = 1.0f;

    }
    public void UpdateInactive(float deltaTime)
    {
        Alpha -= deltaTime / 0.6f;
        if (Alpha < 0.0f)
            Alpha = 0.0f;
    }
}
