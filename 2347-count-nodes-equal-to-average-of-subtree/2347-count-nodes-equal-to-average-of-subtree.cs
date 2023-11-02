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
    private int count = 0;

    public int AverageOfSubtree(TreeNode root) 
    {
        CalculateAverage(root);
        return count;
    }

    private (int, int) CalculateAverage(TreeNode node)
    {
        if (node == null)
        {
            return (0, 0);
        }

        (int leftSum, int leftCount) = CalculateAverage(node.left);
        (int rightSum, int rightCount) = CalculateAverage(node.right);

        int subtreeSum = leftSum + rightSum + node.val;
        int subtreeCount = 1 + leftCount + rightCount;

        if (subtreeSum / subtreeCount == node.val)
            count++;

        return (subtreeSum, subtreeCount);
    }
}