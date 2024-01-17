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
            gameObject.transform.position = startPos; // reset object position
            gameObject.transform.rotation = startRot; // reset object rotation
        }
    }
}
