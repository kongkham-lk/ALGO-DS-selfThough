public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, string[]> graph = new();
        graph.Add("f", new string[] { "g", "i" });
        graph.Add("g", new string[] { "h" });
        graph.Add("h", new string[] { });
        graph.Add("i", new string[] { "g", "k" });
        graph.Add("j", new string[] { "i" });
        graph.Add("k", new string[] { });

        Console.WriteLine(HasPath_DFS(graph, "f", "k")); // false
        Console.WriteLine(HasPath_BFS(graph, "j", "h")); // true
    }

    public static bool HasPath_DFS(Dictionary<string, string[]> graph, string src, string target)
    {
        if (src.Equals(target))
            return true;

        if (!graph[src].Any())
            return false;
        else
            foreach (string next in graph[src])
            {
                if (HasPath_DFS(graph, next, target))
                    return true;
            }

        return false;
    }

    public static bool HasPath_BFS(Dictionary<string, string[]> graph, string src, string target)
    {
        if (src.Equals(target))
            return true;

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
                    if (target.Equals(next))
                        return true;
                    else
                        queue.Enqueue(next);
                }
        }

        return false;
    }
}