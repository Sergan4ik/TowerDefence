using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public sealed class PathComponent : IComponent
{
    public int pathNumber;
    public int currentStage;
}
[FlagPrefix("require")]
public sealed class RedirectPathComponent : IComponent { }

[Unique]
public sealed class PathConfigComponent : IComponent
{
    public List<List<(int, string)>> pathVariants; // sorted in lexicographical order
}