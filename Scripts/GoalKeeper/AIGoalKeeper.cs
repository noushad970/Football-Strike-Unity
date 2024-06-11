using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGoalKeeper : MonoBehaviour
{
    int num;
    bool isDive=false;
    public Animator anim;
    private void Start()
    {
        num = Random.Range(1, 6);
        StartCoroutine(AIGKSave());
    }
    IEnumerator AIGKSave()
    {
        yield return new WaitForSeconds(0.7f);
        if(num==1)
        {
            anim.Play("DiveLeft");
        }
        else if(num==2)
        {
            anim.Play("DiveRight");
        }
        else if(num==3)
        {
            anim.Play("StandingSave");   
        }
        else if (num == 4)
        {
            anim.Play("StandingSaveHigh");
        }
        else if (num == 5)
        {
            anim.Play("LowDiveLeft");
        }
        else if (num == 6)
        {
            anim.Play("LowDiveRight");
        }

    }

}
