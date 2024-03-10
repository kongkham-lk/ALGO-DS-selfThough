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

        if (!IsValidBST(root.left)) // dig down only the left branch until no sub left branch found
            return false;

        if (min >= root.val) // compare if previous node less than current node
            return false;

        min = root.val; // assign the current node

        if (!IsValidBST(root.right)) // dig down only the right branch until no sub right branch found
            return false;

        return true;
    }
}