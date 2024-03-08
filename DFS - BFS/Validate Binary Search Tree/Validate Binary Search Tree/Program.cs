public class Program
{
    public static void Main(string[] args)
    {
        TreeNode root = new() // given [5,1,4,null,null,3,6]
        {
            val = 5,
            left = new() 
            { 
                val = 1,
                left = null,
                right = null
            },
            right = new()
            {
                val = 4,
                left = new()
                {
                    val = 3,
                    left = null,
                    right = null,
                },
                right = new() 
                { 
                    val = 6,
                    left = null,
                    right = null
                }
            }
        };

        Console.WriteLine(IsValidBST(root));
    }

    public static bool IsValidBST(TreeNode root)
    {
        if (root == null)
            return true;

        if (root.left != null && root.left.val < root.val)
            if (!Explore(root.left, root))
                return false;

        if (root.right != null && root.right.val > root.val)
            if (!Explore(root.right, root))
                return false;

        return true;
    }

    public static bool Explore (TreeNode root, TreeNode rootOfParent)
    {
        if (root == null)
            return true;

        if (root.left != null && root.left.val < root.val)
            if (!IsValidBST(root.left))
                return false;

        if (root.right != null && root.right.val > root.val)
            if (!IsValidBST(root.right))
                return false;

        if (root.left != null && root.left.val >= root.val || root.right != null && root.right.val <= root.val)
            return false;

        return true;
    }
}