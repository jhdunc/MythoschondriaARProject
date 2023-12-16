using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCam : MonoBehaviour
{
    public Camera mainCam;
    private void Start()
    {
        GetComponent<Canvas>().worldCamera = mainCam;
    }
}
