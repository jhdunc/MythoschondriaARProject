using System;
using UnityEngine;

public class PlaybackHitter : MonoBehaviour
{
	[NonSerialized] public bool Active;
	[NonSerialized] public int Id;
	[NonSerialized] public float Radius;
	[NonSerialized] public float Alpha;
	[NonSerialized] public Vector3 Position;

	public void Apply(float time)
    {
		if (!Active)
        {
			gameObject.SetActive(false);
			return;
        }

		gameObject.SetActive(true);

		transform.localPosition = Position;
		var radius = Radius;
		transform.localScale = new Vector3(radius, radius, radius);
    }
}
