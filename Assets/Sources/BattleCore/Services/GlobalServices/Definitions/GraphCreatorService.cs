using System.Collections.Generic;
using System.Linq;
using Dreamteck.Splines;

public class GraphCreatorService : IGraphCreatorService
{
    private readonly PathSetup _pathSetup;

    public GraphCreatorService(PathSetup pathSetup)
    {
        _pathSetup = pathSetup;
    }

    public List<List<(int, string)>> AllPaths 
    {
        get
        {
            var edges = CreateEdgeList(_pathSetup);
            var adjacencyList = CreateAdjacencyList(_pathSetup, edges);
            var incomingEdges = CreateIncomingEdges(_pathSetup, edges);
            return GenerateAllPaths(_pathSetup, adjacencyList , incomingEdges);
        }
    }
    
    private List<List<(int , string)>> GenerateAllPaths(PathSetup pathSetup , in List<List<EdgeInfo>> graph , in List<List<EdgeInfo>> incomeEdges)
    {
        List<List<(int, string)>> paths = new List<List<(int, string)>>();
        foreach (var node in pathSetup.startNodes)
        {
            int idx = pathSetup.nodes.IndexOf(node);
            paths.AddRange(GetPaths(idx ,  graph , incomeEdges));
        }

        return paths;
    }

    private List<List<(int , string)>> GetPaths(int v , in List<List<EdgeInfo>> graph , in List<List<EdgeInfo>> incomeEdges)
    {
        List<int> incomeTimes = new List<int>(Enumerable.Repeat(0, graph.Count));
        incomeTimes[v] = -1; // imagine, that we have one income point to start node
        List<List<(int, string)>> paths = new List<List<(int, string)>>()
        {
            new List<(int, string)>() { (v , "") }
        };
        
        List<int> pointerList = new List<int>() { 0 };
        int currentQueue = 0;
        while (currentQueue < paths.Count)
        {
            int currentPointer = pointerList[currentQueue];
            int currentNode = paths[currentQueue][currentPointer].Item1;
            
            //if (incomeTimes[currentNode] > incomeEdges[currentNode].Count) continue;

            for (var index = 0; index < graph[currentNode].Count; index++)
            {
                var edge = graph[currentNode][index];
                if (index == 0)
                {
                    SetSplineToNodeComeFrom(paths[currentQueue]);
                    
                    paths[currentQueue].Add((edge.To , ""));
                }
                else
                {
                    var list = paths[currentQueue].SkipLast(1).ToList();
                    
                    SetSplineToNodeComeFrom(list);
                    CreateNewPathFromLastNode(list);
                }

                incomeTimes[edge.To]++;

                void SetSplineToNodeComeFrom(List<(int, string)> list)
                {
                    var newValue = list[^1];
                    newValue.Item2 = edge.SplineName;
                    list[^1] = newValue;
                }

                void CreateNewPathFromLastNode(List<(int, string)> list)
                {
                    list.Add((edge.To, ""));
                    paths.Add(list);
                    pointerList.Add(list.Count - 1);
                }
            }

            pointerList[currentQueue]++;
            
            if (pointerList[currentQueue] >= paths[currentQueue].Count) 
                currentQueue++;
        }

        return paths;
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
                SplineName = edge.Item3
            });
        }

        return graph;
    }
    private List<List<EdgeInfo>> CreateIncomingEdges(PathSetup pathSetup , in List<(int , int, string)> edges)
    {
        List<List<EdgeInfo>> graph = new List<List<EdgeInfo>>();

        for (int i = 0; i < pathSetup.nodes.Count; i++)
        {
            graph.Add(new List<EdgeInfo>());
        }

        foreach (var edge in edges)
        {
            graph[edge.Item2].Add(new EdgeInfo()
            {
                To = edge.Item1,
                SplineName = edge.Item3
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
        public string SplineName;
        public override string ToString()
        {
            return $"path to {To} by spline {SplineName}";
        }
    }
}