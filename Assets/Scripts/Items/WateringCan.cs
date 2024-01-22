using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    ParticleSystem spillLiquid; // what particle system is supposed to do 
    ParticleSystem.EmissionModule em; // allows us to control the emmissions aka the functionality of the particle system 
    [SerializeField] float angleOfCan; // the angle of the can will dictate when the particle system is active which can be adjusted 

    void Start()
    {
        spillLiquid = GetComponent<ParticleSystem>(); // if spill liquid is occuring use the particle system attached to the watering can 
        em = spillLiquid.emission; 
    }

    void Update()
    {
        em.enabled = Vector3.Angle(Vector3.down, transform.right) <= angleOfCan; // the particles will only be visable when the object is transformed to a specific angle 
    }
}
