using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public GameObject ball;
    public static float maxForceMultiplier = 25f;  // Max force multiplier for the strongest swipe
    public static float minForceMultiplier = 10f;   // Min force multiplier for the weakest swipe
    public float curlFactor = 1f;
    public Camera mainCam;

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




    // Start is called before the first frame update

    void Update()
    {
        if (shootplayer > 0)
        {

            return;
        }
        DetectSwipe();
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
            minForceMultiplier = 15;
            maxForceMultiplier = 30;


        }
        else
        {
            minForceMultiplier = 12;
            maxForceMultiplier = 30;
        }
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
        ballRb.AddForce(forceDirection * forceMultiplier, ForceMode.Impulse);


    }
}
/*
 * 
 */