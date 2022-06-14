using System.Collections.Generic;

public interface IGraphCreatorService
{
    public List<List<(int , string)>> AllPaths { get; }
}