using Unity.VisualScripting;
using UnityEngine;

public class UnityAnimatorCreator : IAnimatorCreatorService
{
    public IAnimator CreateAnimator(AnimatorOptionsComponent optionsComponent, ViewComponent view)
    {
        UnityAnimator animator = new UnityAnimator(view.instance.gameObject.GetOrAddComponent<Animator>());
        return animator;
    }
}