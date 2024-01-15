using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPlayerHeight : MonoBehaviour
{
    [SerializeField] private float defaultHeight = 1f;
    [SerializeField] private Camera camera;

    private void Resize()
    {
        float headHeight = camera.transform.localPosition.y;
        float scale = defaultHeight / headHeight;
        transform.localScale = Vector3.one * scale;
    }

    private void OnEnable()
    {
        Resize();
    }
}
