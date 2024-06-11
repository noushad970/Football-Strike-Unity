using UnityEngine;

public class SwapDetector : MonoBehaviour
{
    public delegate void SwipeAction();
    public static event SwipeAction OnSwipeLeft;
    public static event SwipeAction OnSwipeRight;

    private Vector2 startTouchPosition, endTouchPosition;
    private float swipeThreshold = 50f; // Minimum distance for a swipe to be registered

    void Update()
    {
        DetectSwipe();
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
                    float swipeDistance = swipeDirection.magnitude;

                    if (swipeDistance >= swipeThreshold)
                    {
                        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                        {
                            // Horizontal swipe
                            if (swipeDirection.x > 0)
                            {
                                OnSwipeRight?.Invoke();
                            }
                            else
                            {
                                OnSwipeLeft?.Invoke();
                            }
                        }
                    }
                    break;
            }
        }
    }
}
