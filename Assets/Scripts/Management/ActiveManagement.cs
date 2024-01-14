using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveManagement : MonoBehaviour
{
    public static ActiveManagement Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
