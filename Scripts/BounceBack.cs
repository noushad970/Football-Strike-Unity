using UnityEngine;

public class BounceBack : MonoBehaviour
{
    public string targetTag = "Player"; // Tag of the object to bounce off
    public float bounceForce = 10f; // Force applied to bounce back

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to this object
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing from this GameObject. Please add a Rigidbody component.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has the specific tag
        if (collision.collider.CompareTag(targetTag))
        {
            // Calculate the bounce direction
            Vector3 bounceDirection = collision.contacts[0].normal;

            // Apply the bounce force
            rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
    }
}
