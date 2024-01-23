using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehavior : MonoBehaviour
{
    // Reference to the bowl models
    public GameObject bowlBeets;
    public GameObject bowlCarrots;
    public GameObject bowlPotatoes;
    public GameObject bowlTomatoes;

    private void OnCollisionEnter(Collision collision)
    {
        // Check which vegetable was cut and which bowl should be spawned
        if (collision.gameObject.CompareTag("Beet"))
        {
            Debug.Log("Knife hit!");

            // Get the position and rotation of the vegetable
            Vector3 vegetablePosition = collision.gameObject.transform.position;
            Quaternion vegetableRotation = collision.gameObject.transform.rotation;
            Quaternion bowlRotation = vegetableRotation;
            vegetableRotation *= Quaternion.Euler(-90f, 0f, 0f);
            bowlRotation *= Quaternion.Euler(0f, 0f, 0f);

            // Destroy the current vegetable
            Destroy(collision.gameObject.gameObject);

            // Instantiate the bowl at the same position and rotation as the destroyed vegetable
            Instantiate(bowlBeets, vegetablePosition, bowlRotation);
        }
        else if (collision.gameObject.CompareTag("Carrot"))
        {
            Debug.Log("Knife hit!");

            // Get the position and rotation of the vegetable
            Vector3 vegetablePosition = collision.gameObject.transform.position;
            Quaternion vegetableRotation = collision.gameObject.transform.rotation;

            // Destroy the current vegetable
            Destroy(collision.gameObject.gameObject);

            // Instantiate the bowl at the same position and rotation as the destroyed vegetable
            Instantiate(bowlCarrots, vegetablePosition, vegetableRotation);
        }
        else if (collision.gameObject.CompareTag("Potato"))
        {
            Debug.Log("Knife hit!");

            // Get the position and rotation of the vegetable
            Vector3 vegetablePosition = collision.gameObject.transform.position;
            Quaternion vegetableRotation = collision.gameObject.transform.rotation;
            Quaternion bowlRotation = vegetableRotation;
            bowlRotation *= Quaternion.Euler(0f, 0f, 0f);

            // Destroy the current vegetable
            Destroy(collision.gameObject.gameObject);

            // Instantiate the bowl at the same position and rotation as the destroyed vegetable
            Instantiate(bowlPotatoes, vegetablePosition, vegetableRotation);
        }
        else if (collision.gameObject.CompareTag("Tomato"))
        {
            Debug.Log("Knife hit!");

            // Get the position and rotation of the vegetable
            Vector3 vegetablePosition = collision.gameObject.transform.position;
            Quaternion vegetableRotation = collision.gameObject.transform.rotation;

            // Destroy the current vegetable
            Destroy(collision.gameObject.gameObject);

            // Instantiate the bowl at the same position and rotation as the destroyed vegetable
            Instantiate(bowlTomatoes, vegetablePosition, vegetableRotation);
        }
    }
}
