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
        IList<int> temp;

        if (root == null)
            return nodes;

        temp = InorderTraversal(root.left);
        if (temp.Any())
        {
            foreach (var n in temp)
                nodes.Add(n);
            temp.Clear();
        }

        nodes.Add(root.val);

        temp = InorderTraversal(root.right);
        if (temp.Any())
        {
            foreach (var n in temp)
                nodes.Add(n);
        }

        return nodes;
    }
}