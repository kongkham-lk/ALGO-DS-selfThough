public class Program
{
    public static void Main(string[] args)
    {
        TreeNode root = new TreeNode(3, 
            new TreeNode(9), 
            new TreeNode(20, new TreeNode(15), new TreeNode(7)));

        IterateTree(LevelOrder_BFS(root));
    }

    public static IList<IList<int>> LevelOrder_BFS(TreeNode root)
    {
        if (root == null) return new List<IList<int>>();

        IList<IList<int>> nodesOrder = new List<IList<int>>();
        Queue<TreeNode> neighbor = new Queue<TreeNode>();

        neighbor.Enqueue(root);

        while (neighbor.Any())
        {
            int size = neighbor.Count;
            List<int> subNodeList = new List<int>();

            while (size > 0)
            {
                TreeNode tempNode = neighbor.Dequeue();
                subNodeList.Add(tempNode.val);

                if (tempNode.left != null)
                    neighbor.Enqueue(tempNode.left);
                if (tempNode.right != null)
                    neighbor.Enqueue(tempNode.right);

                size--;
            }
            nodesOrder.Add(subNodeList);
        }
        return nodesOrder;
    }

    public static IList<IList<int>> LevelOrder_DFS(TreeNode root)
    {
        if (root == null) return new List<IList<int>>();

        IList<IList<int>> nodesOrder = new List<IList<int>>();
        Dictionary<int, List<int>> nodeLevel = new Dictionary<int, List<int>>();

        ExploreLevel(root, 0, ref nodeLevel);

        foreach (var level in nodeLevel)
            nodesOrder.Add(level.Value);

        return nodesOrder;
    }

    public static void ExploreLevel(TreeNode root, int level, ref Dictionary<int, List<int>> nodeLevel)
    {
        if (root == null) 
            return;

        var currLevel = level + 1;

        if (!nodeLevel.ContainsKey(currLevel))
            nodeLevel.Add(currLevel, new List<int>());

        nodeLevel[currLevel].Add(root.val);
        ExploreLevel(root.left, currLevel, ref nodeLevel);
        ExploreLevel(root.right, currLevel, ref nodeLevel);
    }

    public static void IterateTree(IList<IList<int>> root)
    {
        Console.WriteLine("[");
        foreach (IList<int> node in root)
        {
            Console.Write("    [ ");
            foreach (int val in node)
            {
                Console.Write(val + " ");
            }
            Console.Write("] \n");
        }
        Console.WriteLine("]");
    }
}