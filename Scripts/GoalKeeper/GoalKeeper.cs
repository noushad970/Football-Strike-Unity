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
    private Rigidbody rb;
    private bool isLeft=false,isRight=false,isCenter=false;

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
        rb = GetComponent<Rigidbody>();
        SwapDetector.OnSwipeLeft += DiveLeft;
        SwapDetector.OnSwipeRight += DiveRight;
        isCenter = true;
    }

    void OnDestroy()
    {
        SwapDetector.OnSwipeLeft -= DiveLeft;
        SwapDetector.OnSwipeRight -= DiveRight;
    }

    void DiveLeft()
    {

        
        if(isCenter)
        {
            anim.Play("DiveLeft");
           // StartCoroutine(waitSec());
            //StopAllCoroutines();
            //StartCoroutine(MoveToPosition(leftDivePosition));
            isLeft = true;
            isCenter= false;
            isRight= false;
        }
        if (isLeft)
        {

            isLeft = true;
            isCenter = false;
            isRight = false;
        }
        if(isRight)
        {
            anim.Play("DiveLeft");
           // StartCoroutine(waitSec());
            //StopAllCoroutines();
            //StartCoroutine(MoveToPosition(centerPosition));
            isCenter = true;
            isRight = false;
            isLeft= false;
        }
    }

    void DiveRight()
    {
        
        if (isCenter)
        {
            anim.Play("DiveRight");
            //StartCoroutine(waitSec());
            //StopAllCoroutines();
            //StartCoroutine(MoveToPosition(rightDivePosition));
            isLeft = false;
            isCenter = false;
            isRight = true;
        }
        if (isLeft)
        {
            anim.Play("DiveRight");
           // StartCoroutine(waitSec());
            //StopAllCoroutines();
            //StartCoroutine(MoveToPosition(centerPosition));
            isLeft = false;
            isCenter = true;
            isRight = false;
        }
        if (isRight)
        {
            isCenter = false;
            isRight = true;
            isLeft = false;
        }

    }
    IEnumerator waitSec()
    {
        yield return new WaitForSeconds(0.4f);
    }
  

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            rb.MovePosition(Vector3.Lerp(transform.position, targetPosition, diveSpeed * Time.deltaTime));
            yield return null;  
            
        }
    }
}
