using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public string moveAnimationName;
    public string idleAnimationName;
    public string jumpAnimationName;

    private int state = 0;

    private Animator anim;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    public void StartMoveAnimation()
    {
        if (state != 1)
        {
            anim.Play(moveAnimationName);
            state = 1;
        }
    }
    public void StartIdleAnimation()
    {
        if (state!=0)
        {
            anim.Play(idleAnimationName);
            state = 0;
        }
    }
    public void StartJumpAnimation()
    {
        anim.Play(jumpAnimationName);
        state = 2;
    }
}
