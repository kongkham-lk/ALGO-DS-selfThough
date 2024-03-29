﻿using System;
using System.ComponentModel.Design.Serialization;
using System.Security.AccessControl;

public class Program
{
    public static void Main(string[] args)
    {
        TreeNode root1 = new(1, new TreeNode(3, null, new TreeNode(2)), null); // given [1,3,null,null,2]
        TreeNode root2 = new(3, new TreeNode(1), new TreeNode(4, new TreeNode(2), null)); // given [3,1,4,null,null,2]
        TreeNode root3 = new(5, new TreeNode(3, new TreeNode(-2147483648), new TreeNode(2)), new TreeNode(9)); // given [5,3,9,-2147483648,2]

        TreeNode targetRoot = root3;

        PrintTree(targetRoot);

        RecoverTree(targetRoot);

        PrintTree(targetRoot);

        // root1 => [3,1,null,null,2]
        // root2 => [2,1,4,null,null,3]
        // root2 => [5,2,9,-2147483648,3]
    }

    public static TreeNode foundNode = null;
    public static TreeNode foundNode2 = null;
    public static TreeNode pre = new(int.MinValue);

    // use tabulation technique
    public static void RecoverTree(TreeNode curr)
    {
        ExploreTree(curr);
        Swap(foundNode, foundNode2);
    }

    public static void ExploreTree(TreeNode curr)
    {
        if (curr == null)
            return;

        ExploreTree(curr.left);

        if (pre.val > curr.val)
        {
            if (foundNode == null)
                foundNode = pre;
            foundNode2 = curr;
        }
        pre = curr;

        ExploreTree(curr.right);
    }

    public static void Swap(TreeNode rootA, TreeNode rootB)
    {
        var temp = rootA.val;
        rootA.val = rootB.val;
        rootB.val = temp;
    }

    public static List<string> memo = new();

    public static void PrintTree(TreeNode targetRoot)
    {
        Console.Write("[ ");
        Console.Write(targetRoot.val + " ");
        IterateThroughTree(targetRoot);
        Console.WriteLine("]\n");
    }

    public static void IterateThroughTree(TreeNode root)
    {
        if (root == null)
            return;

        var left = root.left == null ? "null" : root.left.val.ToString();
        var right = root.right == null ? "null" : root.right.val.ToString();

        Console.Write(left + " " + right + " ");

        IterateThroughTree(root.left);
        IterateThroughTree(root.right);
    }
}