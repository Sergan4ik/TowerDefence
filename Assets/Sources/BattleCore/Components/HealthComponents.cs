using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class HealthComponent : IComponent
{
    public float amount;
    public float maxAmount;
}

[Cleanup(CleanupMode.DestroyEntity)]
public sealed class DamageComponent : IComponent
{
    public GameEntity dealer;
    public GameEntity receiver;
    public float amount;
}

[Event(EventTarget.Self)]
public sealed class DeadComponent : IComponent { }