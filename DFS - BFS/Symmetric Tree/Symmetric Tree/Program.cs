public class Program
{
    public static void Main(string[] args)
    {
        TreeNode root1 = new(
            1,
            new TreeNode(2, new TreeNode(3), new TreeNode(4)),
            new TreeNode(2, new TreeNode(4), new TreeNode(3))
            );

        TreeNode root2 = new(
            1,
            new TreeNode(2, null, new TreeNode(3)),
            new TreeNode(2, null, new TreeNode(3))
            );

        TreeNode root3 = new(
            1,
            new TreeNode(
                2,
                new TreeNode(3, new TreeNode(5), null),
                new TreeNode(4, null, new TreeNode(6))
                ),
            new TreeNode(
                2,
                new TreeNode(4, new TreeNode(6), null),
                new TreeNode(3, null, new TreeNode(5))
                )
            );

        Console.WriteLine("Check root1:");
        IsSymmetric(root1); // True
        Console.WriteLine("Check root2:");
        IsSymmetric(root2); // False
        Console.WriteLine("Check root3:");
        IsSymmetric(root3); // True
    }

    public static void IsSymmetric(TreeNode root)
    {
        Console.WriteLine(BruteForceSearch(root));// brute force

        Console.WriteLine(RecursionSearch(root.left, root.right) + "\n"); // optimized
    }

    public static bool BruteForceSearch(TreeNode root)
    {
        Queue<TreeNode> list = new();
        int count = 0;

        list.Enqueue(root);
        count++;

        while (list.Any())
        {
            List<int> memo = new();
            int newCount = 0;
            while (count > 0)
            {
                var temp = list.Dequeue();
                count--;

                if (temp.left == null)
                    memo.Add(int.MinValue);
                else
                {
                    list.Enqueue(temp.left);
                    memo.Add(temp.left.val);
                    newCount++;
                }

                if (temp.right == null)
                    memo.Add(int.MinValue);
                else
                {
                    list.Enqueue(temp.right);
                    memo.Add(temp.right.val);
                    newCount++;
                }
            }

            count = newCount;

            for (int i = 0; i < memo.Count / 2; i++)
            {
                if (memo[i] != memo[memo.Count - 1 - i])
                    return false;
            }
        }

        return true;
    }

    public static bool RecursionSearch(TreeNode left, TreeNode right)
    {
        if (left == null || right == null)
            return left?.val == right?.val;
        if (left.val != right.val)
            return false;
        return RecursionSearch(left.left, right.right) && RecursionSearch(left.right, right.left);
    }
}