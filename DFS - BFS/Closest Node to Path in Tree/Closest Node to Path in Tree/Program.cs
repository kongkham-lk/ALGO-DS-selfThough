public class Solution
{
    public static void Main(string[] args)
    {
        TreeNode root1 = new(
            0,
            new TreeNode(1, new TreeNode(4)),
            new TreeNode(2, new TreeNode(5), new TreeNode(6)),
            new TreeNode(3)
        );
        TreeNode root2 = new(0, new TreeNode(1, new TreeNode(2)));

        int[][] queries1 = new int[][]
        {
            new int[] { 5, 3, 4},
            new int[] { 5, 3, 6}
        };
        int[][] queries2 = new int[][] { new int[] { 0, 1, 2 } };
        int[][] queries3 = new int[][] { new int[] { 0, 0, 0 } };

        PrintList(SearchClosestNodes(root1, 6, queries1)); // [ 0, 2 ]
        PrintList(SearchClosestNodes(root2, 3, queries2)); // [ 1 ]
        PrintList(SearchClosestNodes(root2, 3, queries3)); // [ 0 ]
    }

    public static List<int> SearchClosestNodes(TreeNode root, int nodeNum, int[][] queries)
    {
        if (root == null)
            return null;

        List<int> result = new();
        List<int> memoPath = new();
        int[] memoDistance = new int[nodeNum];
        for (int i = 0; i < nodeNum; i++)
            memoDistance[i] = 0;

        foreach(var q in queries)
        {
            if (q[0] != q[2] && q[1] != q[2])
            {
                TreeNode nearestNode = null;
                ExplorePath(root, q[0], q[1], ref memoPath);
                FindNearestNode(root, memoPath, q[2], ref nearestNode);
                result.Add(nearestNode.val);
            }
            else
                result.Add(q[2]);
        }

        return result;
    }

    public static bool ExplorePath(TreeNode root, int startNode, int endNode, ref List<int> memoPath)
    {
        if (root == null)
            return false;

        if (ExplorePath(root.left, startNode, endNode, ref memoPath)
            || ExplorePath(root.mid, startNode, endNode, ref memoPath)
            || ExplorePath(root.right, startNode, endNode, ref memoPath))
        {
            if (!memoPath.Contains(root.val))
                memoPath.Add(root.val);
            return true;
        }

        if (root.val == startNode || root.val == endNode)
        {
            if (!memoPath.Contains(root.val))
                memoPath.Add(root.val);
            return true;
        }

        return false;
    }

    public static bool FindNearestNode(TreeNode root, List<int> memoPath, int target, ref TreeNode nearestNode)
    {
        if (root == null)
            return false;

        if (FindNearestNode(root.left, memoPath, target, ref nearestNode)
            || FindNearestNode(root.mid, memoPath, target, ref nearestNode)
            || FindNearestNode(root.right, memoPath, target, ref nearestNode))
        {
            if (memoPath.Contains(root.val) && nearestNode == null)
                nearestNode = new TreeNode(root.val);
            return true;
        }

        if (root.val == target)
        {
            if (memoPath.Contains(root.val) && nearestNode == null)
                nearestNode = new TreeNode(root.val);
            return true;
        }

        return false;
    }

    public static void PrintList(List<int> lists)
    {
        Console.Write("[ ");
        foreach(var val in lists)
        {
            Console.Write(val + " ");
        }
        Console.WriteLine("]\n");
    }
}