public interface IAnimator
{
    public void CrossFadeTo(string animationStateName, float crossFadeTime);
    public void SetTrigger(SetTriggerComponent component);
    public void SetFloat(SetFloatComponent component);
    public void SetBool(SetBoolComponent component);
}