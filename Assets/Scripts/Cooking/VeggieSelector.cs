using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VeggieSelector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Beet") || other.gameObject.CompareTag("Carrot") || other.gameObject.CompareTag("Potato") || other.gameObject.CompareTag("Tomato"))
        {
            Debug.Log("Snapped!");

            //Rigidbody veggieRigidbody = other.gameObject.GetComponent<Rigidbody>();
            //veggieRigidbody.isKinematic = true;

            other.gameObject.transform.position = transform.position;
            other.gameObject.transform.rotation = transform.rotation;
        }
    }
}
