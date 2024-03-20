public class Program
{
    public static void Main(string[] args)
    {
        TreeNode root1 = new TreeNode(3,
            new TreeNode(9),
            new TreeNode(20, new TreeNode(15), new TreeNode(7)));
        TreeNode root2 = new TreeNode(1,
            new TreeNode(2, new TreeNode(4), null),
            new TreeNode(3, null, new TreeNode(5)));

        IterateTree(ZigzagLevelOrder(root2));
    }

    public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        if (root == null) return new List<IList<int>>();

        IList<IList<int>> nodesZigZagOrder = new List<IList<int>>();
        Queue<TreeNode> queue = new Queue<TreeNode>();

        queue.Enqueue(root);
        int level = 0;

        while (queue.Any())
        {
            level++;
            int size = queue.Count;
            List<int> nodes = new List<int>();

            while (size > 0)
            {
                TreeNode tempNode = queue.Dequeue();

                nodes.Add(tempNode.val);

                if (tempNode.left != null)
                    queue.Enqueue(tempNode.left);
                if (tempNode.right != null)
                    queue.Enqueue(tempNode.right);

                size--;
            }
            if (level % 2 == 0)
                nodes.Reverse();
            if (nodes.Any())
                nodesZigZagOrder.Add(nodes);
        }
        return nodesZigZagOrder;
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