public class Solution
{
    public static void Main(string[] args)
    {
        TreeNode root = new(
                4,
                new TreeNode(2, new TreeNode(3), new TreeNode(1)),
                new TreeNode(6, new TreeNode(5))
            );

        PrintTreeBFS(AddOneRow(root, 1, 2));
    }

    public static TreeNode AddOneRow(TreeNode root, int val, int depth)
    {
        if (depth == 1)
            return new TreeNode(val, root);

        return ExploreTree(root, val, depth);
    }

    public static TreeNode ExploreTree(TreeNode root, int val, int currDepth)
    {
        if (root == null)
            return null;

        if (currDepth - 1 == 1)
        {
            TreeNode left = new TreeNode(val, root.left);
            TreeNode right = new TreeNode(val, null, root.right);
            root.left = left;
            root.right = right;
        }
        else
        {
            root.left = ExploreTree(root.left, val, currDepth - 1);
            root.right = ExploreTree(root.right, val, currDepth - 1);
        }
        return root;
    }

    public static void PrintTreeBFS(TreeNode root)
    {
        Console.Write("[ ");

        Queue<TreeNode> nodes = new();
        nodes.Enqueue(root);

        while(nodes.Any())
        {
            var tempNode = nodes.Dequeue();

            if (tempNode.val == Int32.MinValue)
            {
                Console.Write("null ");
                continue;
            }
            else
                Console.Write(tempNode.val + " ");

            if (tempNode.left == null)
                nodes.Enqueue(new TreeNode(Int32.MinValue));
            else
                nodes.Enqueue(tempNode.left);

            if (tempNode.right == null)
                nodes.Enqueue(new TreeNode(Int32.MinValue));
            else
                nodes.Enqueue(tempNode.right);
        }
        Console.Write("]");
    } 
}