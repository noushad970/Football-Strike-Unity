using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    public Animator anim;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GoalScored"))
        {
            HandleGoalScored();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoalScored"))
        {
            HandleGoalScored();
        }
    }

    void HandleGoalScored()
    {
        anim.Play("Victory");
        Debug.Log("Goal scored!");
        // Add your logic here to handle what happens when a goal is scored
    }
}
