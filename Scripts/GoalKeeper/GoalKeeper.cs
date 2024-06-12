using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Goalkeeper : MonoBehaviour
{
    public float diveSpeed = 5f; // Speed of diving
    public Vector3 leftDivePosition;  // Position to dive left
    public Vector3 rightDivePosition; // Position to dive right
    public Vector3 centerPosition;    // Center position
    public Animator anim;

    private Collider playerCollider;
    private Transform playerTransform;

    void Update()
    {
        if (playerCollider != null)
        {
            playerCollider.transform.rotation = playerTransform.rotation;
        }
    }
    void Start()
    {
        playerTransform = transform;

        // Get the Collider component attached to the player
        playerCollider = GetComponent<Collider>();
        
        SwapDetector.OnSwipeLeft += DiveRight;
        SwapDetector.OnSwipeRight += DiveLeft;
      
    }

    void OnDestroy()
    {
        SwapDetector.OnSwipeLeft -= DiveRight;
        SwapDetector.OnSwipeRight -= DiveLeft;
    }

    void DiveLeft()
    {  
            anim.Play("DiveLeft");

    }

    void DiveRight()
    {
            anim.Play("DiveRight");
         
    }
   
  
}
