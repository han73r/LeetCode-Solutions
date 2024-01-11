
using System;
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    private int maxDifference = 0;
    public int MaxAncestorDiff(TreeNode root)
    {

        if (root == null)
        {
            return 0;
        }

        Traverse(root, root.val, root.val);

        return maxDifference;
    }

    void Traverse(TreeNode node, int minAncestor, int maxAncestor)
    {
        if (node == null)
        {
            return;
        }

        // Calculate the maximum difference at the current node
        int currentDiff = Math.Max(Math.Abs(node.val - minAncestor), Math.Abs(node.val - maxAncestor));
        maxDifference = Math.Max(maxDifference, currentDiff);

        // Update minAncestor and maxAncestor for the next level of recursion
        minAncestor = Math.Min(minAncestor, node.val);
        maxAncestor = Math.Max(maxAncestor, node.val);

        // Recursive calls for left and right subtrees
        Traverse(node.left, minAncestor, maxAncestor);
        Traverse(node.right, minAncestor, maxAncestor);
    }
}