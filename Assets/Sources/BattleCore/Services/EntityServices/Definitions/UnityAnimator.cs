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
        _animator.CrossFade(animationStateName , crossFadeTime);    
    }
}