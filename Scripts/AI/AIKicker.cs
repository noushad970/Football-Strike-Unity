using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
//Add the script to the AI penalty kicker

public class AIKicker : MonoBehaviour
{
    public GameObject ball; // Reference to the ball GameObject
    public Transform goal;  // Reference to the goal Transform
     float maxForceMultiplier=20f;  // Max force multiplier for the strongest shot
     float minForceMultiplier=13f;   // Min force multiplier for the weakest shot
    public float loftedShotProbability = 0.5f; // Probability of choosing a lofted shot
    public float curlFactor = 1f; // Factor to add curl to the shot
    public Animator anim;
    private Rigidbody ballRb;

    void Start()
    {
        ballRb = ball.GetComponent<Rigidbody>();
        Debug.Log("Out of Condition Min: " + minForceMultiplier + " Max: " + maxForceMultiplier);

        StartCoroutine(playAnim());
    }

    IEnumerator playAnim()
    {
        yield return new WaitForSeconds(1f);
        anim.Play("PenaltyKick");
        yield return new WaitForSeconds(0.7f);
        ShootBall();
    }
    void ShootBall()
    {
        bool isLoftedShot = Random.value < loftedShotProbability;

        // Determine random direction towards the goal
        Vector3 goalPosition = goal.position;
        Vector3 direction = (goalPosition - ball.transform.position).normalized;

        // Add some randomness to the direction
        direction.x += Random.Range(-0.3f, 0.3f);
        direction.z += Random.Range(-0.1f, 0.1f);

        // Calculate the force based on randomization
        float forceMultiplier = Random.Range(minForceMultiplier, maxForceMultiplier);
        Vector3 forceDirection;

        if (isLoftedShot)
        {
            Debug.Log("Is Lofted: Min: " + minForceMultiplier + " Max: " + maxForceMultiplier);
            maxForceMultiplier = 11f;  // Max force multiplier for the strongest shot
            minForceMultiplier = 11f;
            // Lofted shot: include vertical component
            forceDirection = new Vector3(direction.x, Random.Range(0.5f, 1.5f), direction.z).normalized;
        }
        else
        {
            Debug.Log("Is Low: Min: "+minForceMultiplier+" Max: "+maxForceMultiplier);
            maxForceMultiplier = 20f;  // Max force multiplier for the strongest shot
            minForceMultiplier = 15f;
            // Low shot: mostly horizontal
            forceDirection = new Vector3(direction.x, 0, direction.z).normalized;
        }

        // Optionally, apply curl
        Vector3 curlDirection = Vector3.Cross(Vector3.forward, forceDirection) * curlFactor;
        // Apply force and curl to the ball
        ballRb.AddForce(forceDirection * forceMultiplier, ForceMode.Impulse);
        ballRb.AddTorque(curlDirection, ForceMode.Impulse);
    }
}
