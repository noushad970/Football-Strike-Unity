using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootBallShoot : MonoBehaviour
{
    public GameObject ball;
    public Button lowShotButton;
    public Button loftedShotButton;
    public Button curlShotButton;
    public float maxForceMultiplier = 20f;  // Max force multiplier for the strongest swipe
    public float minForceMultiplier = 5f;   // Min force multiplier for the weakest swipe
    public float curlFactor = 1f;

    private Vector2 startTouchPosition, endTouchPosition;
    private bool isLowShot = true;
    private bool isCurlShot = false;

    void Start()
    {
        // Assign button click listeners
        lowShotButton.onClick.AddListener(SetLowShot);
        loftedShotButton.onClick.AddListener(SetLoftedShot);
        curlShotButton.onClick.AddListener(SetCurlShot);
    }

    void Update()
    {
        DetectSwipe();
    }

    void SetLowShot()
    {
        isLowShot = true;
        isCurlShot = false;
        Debug.Log("Low shot selected");
    }

    void SetLoftedShot()
    {
        isLowShot = false;
        isCurlShot = false;
        Debug.Log("Lofted shot selected");
    }

    void SetCurlShot()
    {
        isCurlShot = true;
        Debug.Log("Curl shot selected");
    }

    void DetectSwipe()
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
                    ShootBall(swipeDirection, swipeLength);
                    break;
            }
        }
    }

    void ShootBall(Vector2 direction, float swipeLength)
    {
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();

        // Calculate the force multiplier based on swipe length
        float forceMultiplier = Mathf.Lerp(minForceMultiplier, maxForceMultiplier, swipeLength / Screen.height);

        Vector3 forceDirection;

        if (isLowShot)
        {
            // Low shot: Force direction is mostly horizontal
            forceDirection = new Vector3(direction.x, 0, direction.magnitude).normalized;
        }
        else
        {
            // Lofted shot: Force direction includes vertical component
            forceDirection = new Vector3(direction.x, direction.y, direction.magnitude).normalized;
        }

        if (isCurlShot)
        {
            // Apply curl effect
            Vector3 curlDirection = Vector3.Cross(Vector3.forward, forceDirection) * curlFactor;
            ballRb.AddTorque(curlDirection, ForceMode.Impulse);
        }

        ballRb.AddForce(forceDirection * forceMultiplier, ForceMode.Impulse);
    }
}


