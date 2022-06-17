using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class HealthComponent : IComponent
{
    public float amount;
    public float maxAmount;
}
public sealed class DamageComponent : IComponent { public float amount; }

[Event(EventTarget.Self)]
public sealed class DeadComponent : IComponent { }