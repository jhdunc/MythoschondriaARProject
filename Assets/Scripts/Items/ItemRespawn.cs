using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    // variables setup for reset
    private Vector3 startPos;
    private Quaternion startRot;
    void Start()
    {
        // set variables to starting position and rotation
        startPos = gameObject.transform.position;
        startRot = gameObject.transform.rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Terrain") // if the collision has tag Terrain
        {
            Rigidbody toolRigidbody = gameObject.GetComponent<Rigidbody>(); // save the rigidbody component of the object
            toolRigidbody.isKinematic = true; // enable "Is Kinematic" in order to prevent funky collisions during respawn
            gameObject.transform.position = startPos; // reset object position
            gameObject.transform.rotation = startRot; // reset object rotation
            toolRigidbody.isKinematic = false; // disable "Is Kinematic"
        }
    }
}
