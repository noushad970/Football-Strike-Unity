using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
//Add the script to the AI penalty kicker

public class AIKicker : MonoBehaviour
{
    public GameObject ball;
    float maxForceMultiplier;  // Max force multiplier for the strongest shot
    float minForceMultiplier;   // Min force multiplier for the weakest shot
    public float loftedShotProbability = 0.5f; // Probability of choosing a lofted shot
    public float curlFactor = 1f; // Factor to add curl to the shot
    //
    public float lowKickForce = 20f;
    public float loftedKickForce = 10f;
    public float kickDelay = 1.0f; // Delay to simulate the animation time
                                   //  public Animator anim;
    private GameObject ballInstance;
    private Rigidbody ballRb;
    private Animator anim;
    Transform target;
 
    bool isLoftedShot;
    void Start()
    {
        isLoftedShot = Random.value < loftedShotProbability;
        // Instantiate the ball at the start of the game
        ballInstance = GameManagerAsGK.spawnedBallGK;
        ballRb = ballInstance.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        target = ObjectSpawnerGK.AIShootTarget;
        StartCoroutine(playAnim());
    }
    void Update()
    {
        if (isLoftedShot)
        {
            Debug.Log("Is Lofted: Min: " + minForceMultiplier + " Max: " + maxForceMultiplier);
            maxForceMultiplier = 13f;  // Max force multiplier for the strongest shot
            minForceMultiplier = 18f;
        }
        else
        {
            Debug.Log("Is Low: Min: " + minForceMultiplier + " Max: " + maxForceMultiplier);

            maxForceMultiplier = 20f;  // Max force multiplier for the strongest shot
            minForceMultiplier = 15f;
        }
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
        

        // Determine random direction towards the goal
        Vector3 goalPosition = target.position;
        Vector3 direction = (goalPosition - ball.transform.position).normalized;

        // Add some randomness to the direction
        direction.x += Random.Range(-0.3f, 0.3f);
        direction.z += Random.Range(-0.1f, 0.1f);

        // Calculate the force based on randomization
        float forceMultiplier = Random.Range(minForceMultiplier, maxForceMultiplier);
        Vector3 forceDirection;

        if (isLoftedShot)
        {
        
            // Lofted shot: include vertical component
            forceDirection = new Vector3(direction.x, Random.Range(0.3f, 0.7f), direction.z).normalized;
        }
        else
        {
           
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
/*
 // 
 */