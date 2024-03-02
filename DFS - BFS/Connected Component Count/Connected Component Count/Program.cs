using System.Xml.Linq;

public class Program
{
	public static void Main(string[] args)
	{
		List<int[]> edges = new() 
		{
			new int[] { 1, 2 },
			new int[] { 3 },
			new int[] { 4, 6 },
			new int[] { 5, 6 },
			new int[] { 6, 7 },
			new int[] { 6, 8 },
		};

		Dictionary<int, List<int>> graph = BuildGraph(edges);

		DisplayGraph(graph);
		//Graph - key-value pair
		//[
		//	1: [2]
		//	2: [1]
		//	3: []
		//	4: [6]
		//	5: [6]
		//	6: [4, 5, 7, 8]
		//	7: []
		//	8: []
		//]

		Console.WriteLine("Total connected component: " + CountConnectedComponent(graph)); // return 3
	}

	private static Dictionary<int, List<int>> BuildGraph(List<int[]> edges)
	{
		Dictionary<int, List<int>> graph = new ();

		foreach (var edge in edges)
		{
			foreach (var node in edge)
			{
				if (!graph.Keys.Contains(node))
					graph.Add(node, new List<int>());
			}

			if (edge.Length > 1 && edge[0] != edge[1])
			{
				graph[edge[0]].Add(edge[1]);
				graph[edge[1]].Add(edge[0]);
			}
		}
		return graph;
	}

	private static void DisplayGraph(Dictionary<int, List<int>> graph)
	{
		Console.WriteLine("Graph = [");

		foreach(var node in graph)
		{
			Console.Write("    { " + node.Key + " : [");
			for (int i = 0; i < node.Value.Count; i++)
			{
				Console.Write(node.Value[i]);

				if(i < node.Value.Count - 1)
					Console.Write(", ");
			}
			Console.WriteLine("] }");
		}
		Console.WriteLine("]\n");
	}

	private static int CountConnectedComponent(Dictionary<int, List<int>> graph)
	{
		List<int> visited = new List<int>();
		int counter = 0;

		foreach(var node in graph)
		{
			if (!HasPath(graph, visited, node.Key))
				counter++;
		}

		return counter;
	}

	private static bool HasPath(Dictionary<int, List<int>> graph, List<int> visited, int src)
	{
		if (visited.Contains(src))
			return true;

		visited.Add(src); // add 1, 2, 3, 4, 6, 5

		foreach (var next in graph[src])
		{
			if (HasPath(graph, visited, next))
				continue;
		}
		return false;
	}
}