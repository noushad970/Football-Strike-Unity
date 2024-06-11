using System.Collections;
using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    public Animator ShooterAIanim;
    public Animator GoalKeeperAIanim;
    bool goalScored=false;
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
            goalScored = true;
            HandleGoalScored();
        }
        if(BallScript.playerIsShooting)
        {
            StartCoroutine(waitSec());
            if(!goalScored) { 
            HandleGoalSave();
            }
        }
    }
    IEnumerator waitSec()
    {
        yield return new WaitForSeconds(1f);
    }
    void HandleGoalScored()
    {
        ShooterAIanim.Play("Victory");
        Debug.Log("Goal scored!");
        // Add your logic here to handle what happens when a goal is scored
    }
    void HandleGoalSave()
    {
        GoalKeeperAIanim.Play("Victory");
        Debug.Log("Goal save!");
        // Add your logic here to handle what happens when a goal is scored
    }

}
