using UnityEngine;

public class PlayerAnimation 
{
    private Animator _animator;

    private const string jumpString = "IsJumping";
    private const string slidingtring = "IsSliding";

    public PlayerAnimation (Animator animator)
    {
        _animator = animator;
    }

    public void ChangeJumpAnimBool(bool jumpState)
    {
        _animator.SetBool(jumpString, jumpState);
    }

    public void ChangeSlidingBool(bool slideState)
    {
        _animator.SetBool(slidingtring, slideState);
    }
}
