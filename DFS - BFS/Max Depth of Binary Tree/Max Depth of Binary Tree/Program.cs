public class Program
{
    public static void Main(string[] args)
    {
        TreeNode root1 = new(3,
                    new TreeNode(9),
                    new TreeNode(20, new TreeNode(15), new TreeNode(7)));

        TreeNode root2 = new(20,
                    new TreeNode(15,
                        new TreeNode(13,
                            null,
                            new TreeNode(14, new TreeNode(10), null)),
                        null),
                    new TreeNode(25, null, new TreeNode(45)));

        Console.WriteLine("Total Depth of root-1 is: " + MaxDepth(root1)); // return 3
        Console.WriteLine("Total Depth of root-2 is: " + MaxDepth(root2)); // return 5
    }


    public static int MaxDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
    }
}