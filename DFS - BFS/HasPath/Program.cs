using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, List<string>> graph1 = new(); // graph with no cycle
        graph1.Add("f", new List<string> { "g", "i" });
        graph1.Add("g", new List<string> { "h" });
        graph1.Add("h", new List<string> { });
        graph1.Add("i", new List<string> { "g", "k" });
        graph1.Add("j", new List<string> { "i" });
        graph1.Add("k", new List<string> { });

        List<string[]> edges = new()
        {
            new string[] { "i", "j" },
            new string[] { "i", "k" },
            new string[] { "j", "k" },
            new string[] { "k", "m" },
            new string[] { "k", "l" },
            new string[] { "o", "n" },
        };

        // add memo for visited node
        Dictionary<string, bool> visited = new();
        foreach (var node in graph1)
            visited.Add(node.Key, false);

        Console.WriteLine(HasPath_DFS(graph1, "f", "k", ref visited)); // true

        Reset(graph1, ref visited);

        Console.WriteLine(HasPath_BFS(graph1, "f", "k", ref visited)); // true

        Reset(graph1, ref visited);

        Console.WriteLine(HasPath_DFS(graph1, "j", "f", ref visited)); // false

        Reset(graph1, ref visited);

        Console.WriteLine(HasPath_BFS(graph1, "j", "f", ref visited)); // true

        Dictionary<string, List<string>> graph2 = BuildGraph(edges);
        visited = new();

        foreach (var node in graph2)
            visited.Add(node.Key, false);

        Console.WriteLine(HasPath_DFS(graph2, "k", "m", ref visited)); // true

        Reset(graph2, ref visited);

        Console.WriteLine(HasPath_BFS(graph2, "k", "m", ref visited)); // true

        Reset(graph2, ref visited);

        Console.WriteLine(HasPath_DFS(graph2, "k", "o", ref visited)); // false

        Reset(graph2, ref visited);

        Console.WriteLine(HasPath_BFS(graph2, "k", "o", ref visited)); // false
    }

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

    public static bool HasPath_DFS(Dictionary<string, List<string>> graph, string src, string target, ref Dictionary<string, bool> visited)
    {
        if (src.Equals(target))
            return true;

        visited[src] = true;

        if (!graph[src].Any())
            return false;
        else
            foreach (string next in graph[src])
            {
                if (!visited[next] && HasPath_DFS(graph, next, target, ref visited)) // skip all the visited node
                {
                    visited[next] = true;
                    return true;
                }
            }

        return false;
    }

    public static bool HasPath_BFS(Dictionary<string, List<string>> graph, string src, string target, ref Dictionary<string, bool> visited)
    {
        if (src.Equals(target))
            return true;

        visited[src] = true;

        Queue<string> queue = new();

        queue.Enqueue(src);

        while(queue.Any())
        {
            string temp = queue.Dequeue();

            if (!graph[temp].Any())
                return false;
            else
                foreach (string next in graph[temp])
                {
                    if (!visited[next]) // skip all the visited node
                    {
                        visited[next] = true;

                        if (target.Equals(next))
                            return true;
                        else
                            queue.Enqueue(next);
                    }
                }
        }

        return false;
    }

    private static void Reset(Dictionary<string, List<string>> graph, ref Dictionary<string, bool> visited)
    {
        foreach (var node in graph)
            visited[node.Key] = false;
    }
}