public class Program
{
    public static void Main(string[] args)
    {
        // Given Graph
        List<int[]> edges = new()
        {
            new int[] { 1, 0 },
            new int[] { 0, 5 },
            new int[] { 0, 8 },
            new int[] { 4, 2 },
            new int[] { 4, 3 },
            new int[] { 2, 3 },
        };

        Dictionary<int, List<int>> graph = Buildgraph(edges);

        Console.WriteLine("The largest component size is: " + LargestComponent(graph));
    }

    private static Dictionary<int, List<int>> Buildgraph(List<int[]> edges)
    {
        Dictionary<int, List<int>> graph = new();

        foreach (var edge in edges)
        {
            foreach (var node in edge)
            {
                if (!graph.Keys.Contains(node))
                    graph.Add(node, new List<int>());
            }

            if (edge.Count() > 1)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
        }
        return graph;
    }

    private static int LargestComponent(Dictionary<int, List<int>> graph)
    {
        int largest = 0;
        int preVisitNum = 0;
        List<int> visited = new();

        foreach (var node in graph)
        {
            if (!HasPath(graph, visited, node.Key))
            {
                int newLargest = visited.Count - preVisitNum;
                largest = Math.Max(largest, newLargest);
                preVisitNum = visited.Count;
            }
        }
        return largest;
    }

    private static bool HasPath(Dictionary<int, List<int>> graph, List<int> visited, int src)
    {
        if (visited.Contains(src))
            return true;

        visited.Add(src);

        foreach (var next in graph[src])
        {
            if (HasPath(graph, visited, next))
                continue;
        }

        return false;
    }
}