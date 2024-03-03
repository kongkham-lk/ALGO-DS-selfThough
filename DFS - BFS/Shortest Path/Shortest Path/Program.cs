public class Program
{
    public static void Main(string[] args)
    {
        List<string[]> edges = new()
        {
            new string[] {"a", "b"},
            new string[] {"a", "c"},
            new string[] {"a", "e"},
            new string[] {"b", "e"},
            new string[] {"b", "d"},
            new string[] {"d", "e"},
            new string[] {"c", "f"},
            new string[] {"c", "g"},
            new string[] {"c", "e"},
            new string[] {"e", "f"},
        };

        Dictionary<string, List<string>> graph = Buildgraph(edges);

        Console.WriteLine("The shortest path length of A-G is: " + FindShortestPath(graph, "a", "g")); // return 2
        Console.WriteLine("The shortest path length of B-G is: " + FindShortestPath(graph, "b", "g")); // return 2
        Console.WriteLine("The shortest path length of C-H is: " + FindShortestPath(graph, "c", "h")); // return -1 (not found)
    }

    private static Dictionary<string, List<string>> Buildgraph(List<string[]> edges)
    {
        Dictionary<string, List<string>> graph = new();

        foreach (var edge in edges)
        {
            foreach (var node in edge)
            {
                if (!graph.Keys.Contains(node))
                    graph.Add(node, new List<string>());
            }

            if (edge.Count() > 1)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
        }
        return graph;
    }

    private static int FindShortestPath (Dictionary<string, List<string>> graph, string node, string target)
    {
        int pathLength = 0;

        Queue<Dictionary<string, int>> queue = new();
        List<string> visited = new();

        queue.Enqueue(new Dictionary<string, int> { { node, pathLength } });
        visited.Add(node);
        while (queue.Any())
        {
            var src = queue.Dequeue();
            pathLength = src.First().Value + 1; // update pathLength base one the value that correspond with the node

            foreach (var next in graph[src.First().Key])
            {
                if (!visited.Contains(next))
                {
                    if (next == target)
                    {
                        return pathLength;
                    }
                    queue.Enqueue(new Dictionary<string, int> { { next, pathLength } });
                    visited.Add(next);;
                }
            }
        }
        return -1;
    }
}