using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenaltyKicker : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(BallScript.playCharacterAnim)
        {

            anim.Play("PenaltyKick");
            BallScript.playCharacterAnim = false;
        }
    }
}
