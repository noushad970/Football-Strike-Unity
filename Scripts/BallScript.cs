using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
public class BallScript : NetworkBehaviour 
{
    public GameObject ball;
    public static float maxForceMultiplier = 25f;  // Max force multiplier for the strongest swipe
    public static float minForceMultiplier = 10f;   // Min force multiplier for the weakest swipe
    public float curlFactor = 1f;
    Rigidbody rb;
    public Camera mainCam;
    public static bool ballSpin;
    private Vector2 startTouchPosition, endTouchPosition;

    private bool isCurlShot = false;
    [Header("Animation")]
    public Animator PlayerAnim;
    [HideInInspector]
    public static bool playerIsShooting = false;
    public static int shootplayer = 0;
    float touchLength;
    public static bool playCharacterAnim = false;

    //public Button curlShotButton;
    //extra
    public float forceMagnitude = 10f; // The magnitude of the force applied to curve the ball
    public float torqueMagnitude = 5f; // The magnitude of the torque applied to curve the ball




    private void Start()
    {
        ballSpin = false;
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update

    void Update()
    {
        if (!IsOwner) return;
        
        DetectSwipeServerRpc();
        if (touchLength > 0)
        {
            playCharacterAnim = true;

            shootplayer++;
            playerIsShooting = true;
        }
        else
        {

            playerIsShooting = false;
            playCharacterAnim = false;

        }
        if (GameManager.isLowShot)
        {
            minForceMultiplier = 20;
            maxForceMultiplier = 30;


        }
        else
        {
            minForceMultiplier = 12;
            maxForceMultiplier = 30;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 initialForce = transform.forward * forceMagnitude;
            rb.AddForce(initialForce, ForceMode.VelocityChange);

            // Apply torque to create the curve effect
            Vector3 torque = new Vector3(1, 1, 0).normalized * torqueMagnitude;
            rb.AddTorque(torque, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwingBallRight();
        }
    }

    void SetCurlShot()
    {
        isCurlShot = true;
        Debug.Log("Curl shot selected");
    }
    [ServerRpc]
    void DetectSwipeServerRpc()
    {
        DetectSwipeClientRpc();
    }

    [ClientRpc]
    void DetectSwipeClientRpc()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {

                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    endTouchPosition = touch.position;
                    Vector2 swipeDirection = endTouchPosition - startTouchPosition;
                    float swipeLength = swipeDirection.magnitude;
                    touchLength = swipeLength;

                    StartCoroutine(ShootBall(swipeDirection, swipeLength));
                    break;
            }
        }
    }

    IEnumerator ShootBall(Vector2 direction, float swipeLength)
    {

        // StartCoroutine(PlayShootAnim());
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();

        // Calculate the force multiplier based on swipe length

        float forceMultiplier = Mathf.Lerp(minForceMultiplier, maxForceMultiplier, swipeLength / Screen.height);

        Vector3 forceDirection;
      //  Vector3 worldDirection = mainCamera.transform.TransformDirection(new Vector3(swipeDirection.x, 0, swipeDirection.y)).normalized;


        if (GameManager.isLowShot)
        {
            
            // Low shot: Force direction is mostly horizontal
            forceDirection = mainCam.transform.TransformDirection(new Vector3(direction.x, 0, direction.magnitude)).normalized;
        }
        else
        {
            
            // Lofted shot: Force direction includes vertical component
            forceDirection = mainCam.transform.TransformDirection(new Vector3(direction.x, direction.y, direction.magnitude)).normalized;
        }

        
        yield return new WaitForSeconds(0.7f);
        ballSpin = true;
        ballRb.AddForce(forceDirection * forceMultiplier, ForceMode.Impulse);


    }
    void SwingBallRight()
    {
        // Add force or adjust trajectory to the right
       // ballRigidbody.AddForce(Vector3.right * 10, ForceMode.Impulse); // Adjust the force value as needed
    }

    void SwingBallLeft()
    {
        // Add force or adjust trajectory to the left
      //  ballRigidbody.AddForce(Vector3.left * 10, ForceMode.Impulse); // Adjust the force value as needed
    }
    public void ApplyCurveForce()
    {
        if (rb != null)
        {
            // Apply the initial force to move the ball forward
            Vector3 initialForce = transform.forward * forceMagnitude;
            rb.AddForce(initialForce, ForceMode.VelocityChange);

            // Apply torque to create the curve effect
            Vector3 torque = new Vector3(1, 1, 0).normalized * torqueMagnitude;
            rb.AddTorque(torque, ForceMode.VelocityChange);
        }
    }
}
/*
 * 
 */