using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public sealed class PathComponent : IComponent
{
    public int pathNumber;
    public int currentStage;
    public PathBehaviourOnEnd behaviourOnEnd;
}
public sealed class PathEndReachedComponent : IComponent { }
[FlagPrefix("require")]
public sealed class RedirectPathComponent : IComponent { }

[Unique]
public sealed class LevelMapComponent : IComponent
{
    public List<List<(int, string)>> pathVariants; // sorted in lexicographical order
}

public enum PathBehaviourOnEnd
{
    Stop = 0,
    Loop = 1
}
