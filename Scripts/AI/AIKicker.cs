using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
//Add the script to the AI penalty kicker

public class AIKicker : MonoBehaviour
{
    
    public Transform target;
    public float lowKickForce = 5f;
    public float loftedKickForce = 20f;
    public float kickDelay = 1.0f; // Delay to simulate the animation time
  //  public Animator anim;
    private GameObject ballInstance;
    private Rigidbody ballRb;
    private Animator anim;

    void Start()
    {
        // Instantiate the ball at the start of the game
        ballInstance = GameManagerAsGK.spawnedBallGK;
        ballRb = ballInstance.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        StartCoroutine(playAnim());
    }
    IEnumerator playAnim()
    {
        yield return new WaitForSeconds(1f);
        anim.Play("PenaltyKick");
        yield return new WaitForSeconds(0.7f);
        KickBall();
    }

    void KickBall()
    {
        if (ballRb != null)
        {
            // Calculate the direction towards the target
            Vector3 directionToTarget = (target.position +ballInstance.transform.position).normalized;

            // Randomly decide whether to kick low or lofted
            bool isLowShot = Random.value > 0.5f;
            float force = isLowShot ? lowKickForce : loftedKickForce;
            Vector3 kickDirection = directionToTarget;

            // Adjust the Y component for lofted shots
            if (!isLowShot)
            {
                kickDirection.y = 1.0f; // Modify as needed for the desired loft
            }

            // Apply force to the ball
            ballRb.AddForce(kickDirection * force, ForceMode.Impulse);
        }
    }
}
/*
 // 
 */