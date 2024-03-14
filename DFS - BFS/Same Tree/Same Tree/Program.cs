public class Program
{
    public static void Main(string[] args)
    {
        TreeNode p = new TreeNode(1, null, new TreeNode(1));
        TreeNode q = new TreeNode(1 , null, new TreeNode(1));
        Console.WriteLine(IsSameTree(p, q));
    }

    public static bool IsSameTree(TreeNode p, TreeNode q)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();

        if (p == q) 
            return true;
        else if (p != null && q == null || p == null && q != null)
            return false;
        else if (p.val != q.val)
            return false;

        queue.Enqueue(p);
        queue.Enqueue(q);

        while (queue.Any())
        {
            var temp1 = queue.Dequeue();
            var temp2 = queue.Dequeue();

            if (temp1.left != null && temp2.left == null || temp1.left == null && temp2.left != null)
                return false;
            else if (temp1.right == null && temp2.right != null || temp1.right != null && temp2.right == null)
                return false;
            else
            {
                if (temp1.left != null)
                {
                    if (temp1.left.val != temp2.left.val)
                        return false;
                    queue.Enqueue(temp1.left);
                    queue.Enqueue(temp2.left);
                }

                if (temp1.right != null)
                {
                    if (temp1.right.val != temp2.right.val)
                        return false;
                    queue.Enqueue(temp1.right);
                    queue.Enqueue(temp2.right);
                }
            }
        }
        return true;
    }
}