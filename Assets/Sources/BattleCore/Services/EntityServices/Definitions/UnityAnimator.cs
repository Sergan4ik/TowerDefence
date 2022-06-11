using UnityEngine;

public class UnityAnimator : IAnimator
{
    private readonly Animator _animator;

    public UnityAnimator(Animator animator)
    {
        _animator = animator;
    }
    
    public void CrossFadeTo(string animationStateName, float crossFadeTime)
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).shortNameHash == Animator.StringToHash(animationStateName) || _animator.IsInTransition(0))
            return;
        _animator.CrossFadeInFixedTime(animationStateName , crossFadeTime);    
    }
}