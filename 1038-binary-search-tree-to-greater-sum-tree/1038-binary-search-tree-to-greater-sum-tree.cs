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
    private int sum = 0;
    public TreeNode BstToGst(TreeNode root) {
        if (root == null) return null;
        BstToGst(root.right);
        sum += root.val;
        root.val = sum;
        BstToGst(root.left);
        return root;
    }
}