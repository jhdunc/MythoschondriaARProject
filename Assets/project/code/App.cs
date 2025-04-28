using System;
using System.Collections.Generic;
using ADG;
using insitu;
using UnityEngine;


[CreateAssetMenu]
public class App : insitu.App
{
	[NonSerialized] public Telemetry Telemetry;
	[NonSerialized] public Ease.Func EaseFunc;
	[NonSerialized] public List<Hitter> Hitters;

	public Playback PlaybackAsset;
}
