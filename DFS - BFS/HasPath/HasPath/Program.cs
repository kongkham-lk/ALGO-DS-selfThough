using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, List<string>> graph1 = new() // directed graph with no cycle
        {
            { "f", new List<string> { "g", "i" } },
            { "g", new List<string> { "h" } },
            { "h", new List<string> { } },
            { "i", new List<string> { "g", "k" } },
            { "j", new List<string> { "i" } },
            { "k", new List<string> { } },
        }; 

        List<string[]> edges = new() // represent undirected graph
        {
            new string[] { "i", "j" },
            new string[] { "i", "k" },
            new string[] { "j", "k" },
            new string[] { "k", "m" },
            new string[] { "k", "l" },
            new string[] { "o", "n" },
        };

        // add memo for visited node
        List<string> memo = new();

        Console.WriteLine(HasPath_DFS(graph1, "f", "k", memo)); // true

        memo = new();

        Console.WriteLine(HasPath_BFS(graph1, "f", "k", memo)); // true

        memo = new();

        Console.WriteLine(HasPath_DFS(graph1, "j", "f", memo)); // false

        memo = new();

        Console.WriteLine(HasPath_BFS(graph1, "j", "f", memo)); // true
                
        Dictionary<string, List<string>> graph2 = BuildGraph(edges);

        memo = new();

        Console.WriteLine(HasPath_DFS(graph2, "k", "m", memo)); // true

        memo = new();

        Console.WriteLine(HasPath_BFS(graph2, "k", "m", memo)); // true

        memo = new();

        Console.WriteLine(HasPath_DFS(graph2, "k", "o", memo)); // false

        memo = new();

        Console.WriteLine(HasPath_BFS(graph2, "k", "o", memo)); // false
    }

    /// <summary>
    /// convert undirected graph to directed graph
    /// </summary>
    /// <param name="edges"></param>
    /// <returns></returns>
    private static Dictionary<string, List<string>> BuildGraph(List<string[]> edges)
    {
        Dictionary<string, List<string>> graph = new();

        foreach (string[] edge in edges)
        {
            if (!graph.Keys.Contains(edge[0]))
                graph.Add(edge[0], new List<string>());
            if (!graph.Keys.Contains(edge[1]))
                graph.Add(edge[1], new List<string>());

            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        return graph;
    }

    /// <summary>
    /// search target node with depth first search
    /// </summary>
    /// <param name="graph"></param>
    /// <param name="src"></param>
    /// <param name="target"></param>
    /// <param name="visited"></param>
    /// <returns></returns>
    public static bool HasPath_DFS(Dictionary<string, List<string>> graph, string src, string target,  List<string> visited)
    {
        if (src.Equals(target))
            return true;

        visited.Add(src);

        if (!graph[src].Any())
            return false;
        else
            foreach (string next in graph[src])
            {
                if (!visited.Contains(next) && HasPath_DFS(graph, next, target, visited)) // skip all the visited node
                {
                    visited.Add(next);
                    return true;
                }
            }

        return false;
    }

    /// <summary>
    /// search target node with breath first search
    /// </summary>
    /// <param name="graph"></param>
    /// <param name="src"></param>
    /// <param name="target"></param>
    /// <param name="visited"></param>
    /// <returns></returns>
    public static bool HasPath_BFS(Dictionary<string, List<string>> graph, string src, string target, List<string> visited)
    {
        if (src.Equals(target))
            return true;

        Queue<string> queue = new();

        queue.Enqueue(src);

        while(queue.Any())
        {
            string temp = queue.Dequeue();

            visited.Add(temp);

            if (!graph[temp].Any())
                return false;
            else
                foreach (string next in graph[temp])
                {
                    if (!visited.Contains(next)) // skip all the visited node
                    {
                        visited.Add(next);

                        if (target.Equals(next))
                            return true;
                        else
                            queue.Enqueue(next);
                    }
                }
        }

        return false;
    }
}