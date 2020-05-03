using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public string moveAnimationName;
    public string idleAnimationName;
    public string jumpAnimationName;
    public string shootAnimationName;

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
    public void StartShootAnimation()
    {
        if (state != 3)
        {
            anim.Play(shootAnimationName);
            state = 3;
        }
    }
}
