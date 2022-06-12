using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;

public class GraphCreator
{
    private readonly PathSetup _pathSetup;

    public GraphCreator(PathSetup pathSetup)
    {
        _pathSetup = pathSetup;
    }

    public List<List<(int, string)>> AllPaths 
    {
        get
        {
            var edges = CreateEdgeList(_pathSetup);
            var adjacencyList = CreateAdjacencyList(_pathSetup, edges);
            return GenerateAllPaths(_pathSetup, adjacencyList);
        }
    }
    
    private List<List<(int , string)>> GenerateAllPaths(PathSetup pathSetup , in List<List<EdgeInfo>> graph)
    {
        List<List<(int, string)>> paths = new List<List<(int, string)>>();
        HashSet<int> visited = new HashSet<int>();
        foreach (var node in pathSetup.startNodes)
        {
            visited.Clear();
            int idx = pathSetup.nodes.IndexOf(node);
            paths.Add(new List<(int, string)>());
            paths.Last().Add((idx, ""));
            GetPaths(idx, paths.Count - 1, ref paths , ref visited , graph);
        }

        return paths;
    }

    private void GetPaths(int v , int curPath , ref List<List<(int, string)>> paths , ref HashSet<int> visited , in List<List<EdgeInfo>> graph)
    {
        if (visited.Contains(v))
            return;
        visited.Add(v);
        int countBefore = paths.Count;
        for (var index = 0; index < graph[v].Count; index++)
        {
            var edge = graph[v][index];
            if (index > 0)
            {
                paths.Add(new List<(int, string)>());
                paths.Last().AddRange(paths[curPath].SkipLast(1));
                paths[countBefore + (index - 1)].Add((edge.To , edge.PathName));
            }
            else
            {
                paths[curPath].Add((edge.To , edge.PathName));
            }
        }

        for (var index = 0; index < graph[v].Count; index++)
        {
            var edge = graph[v][index];
            GetPaths(edge.To , curPath + index, ref paths , ref visited , graph);
        }
    }

    private List<List<EdgeInfo>> CreateAdjacencyList(PathSetup pathSetup , in List<(int , int, string)> edges)
    {
        List<List<EdgeInfo>> graph = new List<List<EdgeInfo>>();

        for (int i = 0; i < pathSetup.nodes.Count; i++)
        {
            graph.Add(new List<EdgeInfo>());
        }

        foreach (var edge in edges)
        {
            graph[edge.Item1].Add(new EdgeInfo()
            {
                To = edge.Item2,
                PathName = edge.Item3
            });
        }

        return graph;
    }

    private List<(int, int , string)> CreateEdgeList(PathSetup pathSetup)
    {
        List<(int, int, string)> edges = new List<(int, int, string)>();
        HashSet<string> visited = new HashSet<string>();
        
        foreach (var node in pathSetup.startNodes)
            ScanGraph(node ,  edges , pathSetup , ref visited);

        edges.Sort();
        return edges;
    }

    private void ScanGraph(Node t , in List<(int,int,string)> edges , in PathSetup pathSetup , ref HashSet<string> visited) 
    {
        if (visited.Contains(t.name))
            return;
        visited.Add(t.name);
        
        foreach (var con in t.GetConnections())
        {
            var nodesDict = con.spline.GetNodes();
            nodesDict = nodesDict.OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);
            var nextNode = nodesDict.FirstOrDefault(n => n.Key > con.pointIndex).Value;
            if (nextNode == null)
                continue;
            edges.Add((pathSetup.nodes.IndexOf(t) , pathSetup.nodes.IndexOf(nextNode) , con.spline.name));
            ScanGraph(nextNode , edges , pathSetup , ref visited);
        }
    }
    
    public struct EdgeInfo
    {
        public int To;
        public string PathName;
        public override string ToString()
        {
            return $"path to {To} by spline {PathName}";
        }
    }
}