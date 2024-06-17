using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetection : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has the tag "Ball"
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Print a debug message to the console
            Debug.Log("Goooooaaaaaal");
        }
    }
}
