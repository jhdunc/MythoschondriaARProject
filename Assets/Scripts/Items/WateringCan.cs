using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    ParticleSystem spillLiquid;
    ParticleSystem.EmissionModule em;
    [SerializeField] float angleOfCan;

    void Start()
    {
        spillLiquid = GetComponent<ParticleSystem>();
        em = spillLiquid.emission;
    }

    void Update()
    {
        em.enabled = Vector3.Angle(Vector3.down, transform.right) <= angleOfCan;
        if (em.enabled)
            FindObjectOfType<AudioManager>().Play("Watering"); // plays water SFX
    }
}
