using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using ADG;
using insitu;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Game : MonoBehaviour
{
    [NonSerialized] public float GameStart;
    [NonSerialized] public float NextSpawn;
    [NonSerialized] public uint SpawnIndex;

    [NonSerialized] public float Alpha;

    public Main main;

    [Header("UI Display 1")]
    public Canvas Canvas;
    public CanvasGroup Group;

    public void Awake()
    {
        XRSettings.gameViewRenderMode = GameViewRenderMode.None;
    }

    public void Initialize(Main main)
    {
        var app = main.App;
        uint seed = app.Settings["seed"];
        if (seed == 0)
            seed = (uint)UnityEngine.Random.Range(13, int.MaxValue);

        NextSpawn = GameStart = Time.time + 4.9f;
        SpawnIndex = Hash.Simple(seed, 11690143U);
        
        Clear();
    }

    public void Clear()
    {
        // EDIT ME //
        //
        // Called in Game.Initialize method from Main.StartGame()
        // Can be used to clear game objects if tracked in an Array.
  
    }
    public void Update()
    {
        var enable_canvas = Alpha > 0.0001f;
        if (!enable_canvas)
            Canvas.enabled = false;

        var alpha = Ease.Hermite(Alpha);
        Group.alpha = alpha;
        Group.blocksRaycasts = alpha >= 0.9999f;

        if (enable_canvas)
            Canvas.enabled = true;
    }

    public void UpdateActive(Main main, float deltaTime)
    {
        var app = main.App;
        if (!App.FetchState(app))
        {
            UpdateInactive(deltaTime);
            return;
        }

        Alpha += deltaTime / 0.6f;
        if (Alpha >= 1.0f)
            Alpha = 1.0f;

        var settings = app.Settings;
        var time = Time.time;

        if (time > NextSpawn)
        {
            var min_wait = Mathf.Max(settings["min_wait"], 0.05f);
            var max_wait = Mathf.Max(settings["max_wait"], min_wait);
            var wait = Mathf.Lerp(min_wait, max_wait, Hash.Noise(SpawnIndex, 10909601U));

            //INFO //
            // applied settings for HITTERS //
            //var type = 1;
            var weight_any = (float)settings.NumberOf("any_weight", 0.2f);
            var weight_single = (float)settings.NumberOf("single_weight", 0.8f);
            var weight_total = weight_any + weight_single;
            var type_alpha = weight_total * Hash.Noise(SpawnIndex, 3531976781U);
            if (type_alpha <= weight_any)
/*            
            {
                type = 1;
            }
*/

            type_alpha -= weight_any;

            var hitters = app.Hitters;
            if (hitters != null && hitters.Count > 0 && type_alpha <= weight_single)
            {
                var hitter_total = 0.0f;
                for (var i = 0; i < hitters.Count; i++)
                    hitter_total += hitters[i].Weight;

                var index = 0;
                var index_rnd = hitter_total * Hash.Noise(SpawnIndex, 2743200253U);
                for (var i = 0; i < hitters.Count; i++)
                {
                    var element = hitters[i];
                    index_rnd -= element.Weight;
                    if (index_rnd <= 0)
                    {
                        index = i;
                        break;
                    }
                }
            }
            NextSpawn += wait;
            SpawnIndex++;
        }
    }
    public void UpdateInactive(float deltaTime)
    {
        Alpha -= deltaTime / 0.6f;
        if (Alpha < 0.0f)
            Alpha = 0.0f;
    }

    public static Vector3 VectorOf(float yew, float pitch, float distance) =>
        Quaternion.AngleAxis(yew, Vector3.up) *
        Quaternion.AngleAxis(pitch, Vector3.right) *
        new Vector3(0, 0, distance);
}
