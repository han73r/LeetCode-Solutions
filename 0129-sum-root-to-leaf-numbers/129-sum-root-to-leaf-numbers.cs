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
    public int SumNumbers(TreeNode root) {
        return Deep(root, 0);
    }

    private int Deep(TreeNode node, int temp) {
        if (node == null) {
            return 0;
        }
        temp = temp * 10 + node.val;

        if (node.left == null && node.right == null) {
            return temp;
        }
        int leftSum = Deep(node.left, temp);
        int rightSum = Deep(node.right, temp);
        return leftSum + rightSum;
    }
}