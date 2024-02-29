public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, string[]> graph1 = new(); // graph with no cycle
        graph1.Add("f", new string[] { "g", "i" });
        graph1.Add("g", new string[] { "h" });
        graph1.Add("h", new string[] { });
        graph1.Add("i", new string[] { "g", "k" });
        graph1.Add("j", new string[] { "i" });
        graph1.Add("k", new string[] { });

        Dictionary<string, string[]> graph2 = new(); // graph with cycle
        graph2.Add("i", new string[] { "j", "k" });
        graph2.Add("j", new string[] { "i", "k" });
        graph2.Add("k", new string[] { "i", "j", "m", "l" });
        graph2.Add("l", new string[] { "k" });
        graph2.Add("m", new string[] { "k" });
        graph2.Add("n", new string[] { "o" });
        graph2.Add("o", new string[] { "n" });

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

    public static bool HasPath_DFS(Dictionary<string, string[]> graph, string src, string target, ref Dictionary<string, bool> visited)
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

    public static bool HasPath_BFS(Dictionary<string, string[]> graph, string src, string target, ref Dictionary<string, bool> visited)
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

    private static void Reset(Dictionary<string, string[]> graph, ref Dictionary<string, bool> visited)
    {
        foreach (var node in graph)
            visited[node.Key] = false;
    }
}