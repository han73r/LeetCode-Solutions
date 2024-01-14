
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
    private int maxi = int.MinValue;

    public int AmountOfTime(TreeNode root, int start)
    {
        CalculateInfectionTime(root, start, true);
        return maxi;
    }

    private int CalculateInfectionTime(TreeNode root, int start, bool isStartNode)
    {
        if (root == null) return 0;

        if (root.val == start && isStartNode)
        {
            maxi = Math.Max(maxi, CalculateInfectionTime(root, start, false) - 1);
            return -1;
        }

        int leftHeight = CalculateInfectionTime(root.left, start, isStartNode);
        int rightHeight = CalculateInfectionTime(root.right, start, isStartNode);

        if (leftHeight < 0 || rightHeight < 0)
        {
            maxi = Math.Max(maxi, Math.Abs(leftHeight) + Math.Abs(rightHeight));
            return Math.Min(leftHeight, rightHeight) - 1;
        }

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}