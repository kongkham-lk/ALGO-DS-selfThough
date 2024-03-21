public class Program
{
    public static void Main(string[] args)
    {
        TreeNode root = new(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

        IterateList(LevelOrderBottom(root)); // Output: [[15,7],[9,20],[3]]
    }

    public static IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        if (root == null)
            return new List<IList<int>>();

        List<IList<int>> nodeList = new List<IList<int>>();
        Queue<TreeNode> queue = new Queue<TreeNode>();

        queue.Enqueue(root);

        while (queue.Any())
        {
            int size = queue.Count;
            List<int> ints = new();

            while (size > 0)
            {
                TreeNode node = queue.Dequeue();
                ints.Add(node.val);

                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);

                size--;
            }
            nodeList.Add(ints);
        }
        nodeList.Reverse();
        return nodeList.ToList();
    }

    public static void IterateList(IList<IList<int>> levels)
    {
        Console.WriteLine("[");
        foreach(var level in levels)
        {
            Console.Write("    [ ");
            foreach(var val in level)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine("]");
        }
        Console.WriteLine("]");
    }
}