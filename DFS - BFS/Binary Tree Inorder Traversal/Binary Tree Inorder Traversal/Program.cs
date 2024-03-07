using System.Xml.Linq;
using Binary_Tree_Inorder_Traversal;

public class Program
{
    public static void Main(string[] args)
    {
        TreeNode root = new()
        {
            val = 1,
            left = null,
            right = new TreeNode()
            {
                val = 2,
                left = new TreeNode()
                {
                    val = 3,
                    left = null,
                    right = null
                },
                right = null
            }
        };

        var lists = InorderTraversal(root);

        Console.Write("[ ");
        foreach (var node in lists)
        {
            Console.Write(node + ", ");
        }
        Console.Write("]");
    }

    public static IList<int> InorderTraversal(TreeNode root)
    {
        IList<int> nodes = new List<int>();

        Explore(root, nodes);

        return nodes;
    }

    public static void Explore(TreeNode root, IList<int> nodes)
    {
        if (root != null)
        {
            Explore(root.left, nodes);
            nodes.Add(root.val);
            Explore(root.right, nodes);
        }
    }
}