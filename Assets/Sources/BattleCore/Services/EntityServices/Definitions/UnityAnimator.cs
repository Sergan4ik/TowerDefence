using TMPro.EditorUtilities;
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

    public void SetTrigger(SetTriggerComponent component)
    {
        _animator.SetTrigger(component.triggerName);
    }

    public void SetFloat(SetFloatComponent component)
    {
        _animator.SetFloat(component.parameterName , component.value);
    }

    public void SetBool(SetBoolComponent component)
    {
        _animator.SetBool(component.parameterName , component.value);
    }

    public void SetInt(string parameterName, int value)
    {
        _animator.SetInteger(parameterName , value);
    }
}