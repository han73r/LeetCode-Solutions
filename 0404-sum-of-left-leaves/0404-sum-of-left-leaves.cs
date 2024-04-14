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
public class Solution {
    public int SumOfLeftLeaves(TreeNode root) {
        if (root == null) return 0;
        int sum = 0;
        if (IsLeaf(root.left)) sum += root.left.val;
        sum += SumOfLeftLeaves(root.left);
        sum += SumOfLeftLeaves(root.right);
        return sum;
    }

    private bool IsLeaf(TreeNode node) {
        return node != null && node.left == null && node.right == null;
    }
}