using Entitas;
using Entitas.CodeGeneration.Attributes;

public sealed class CrossFadeRequestComponent : IComponent
{
    public string animationStateName;
    public float crossFadeTime;
}
[FlagPrefix("need")]
public sealed class AnimatorComponent : IComponent { }

public sealed class AnimatorOptionsComponent : IComponent
{
    public float placeholder;
}

public sealed class AnimatorObjectComponent : IComponent
{
    public IAnimator instance;
}

public sealed class SetTriggerComponent : IComponent { public string triggerName; }
public sealed class SetBoolComponent : IComponent 
{ 
    public string parameterName; 
    public bool value;
}

public sealed class SetFloatComponent : IComponent
{
    public string parameterName;
    public float value;
}