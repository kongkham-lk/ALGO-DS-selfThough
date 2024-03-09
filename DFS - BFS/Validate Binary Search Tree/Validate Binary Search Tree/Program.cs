public class Program
{
    public static void Main(string[] args)
    {
        TreeNode root = new() // given [5,1,4,null,null,3,6]
        {
            val = 0,
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
                }
            }
        };

        Console.WriteLine(IsValidBST(root));
    }

    public static long min = Int64.MinValue;

    // use tabulation technique
    public static bool IsValidBST(TreeNode root)
    {
        if (root == null)
            return true;

        if (!IsValidBST(root.left))
            return false;

        if (min >= root.val)
            return false;

        min = root.val;

        if (!IsValidBST(root.right))
            return false;

        return true;
    }
}