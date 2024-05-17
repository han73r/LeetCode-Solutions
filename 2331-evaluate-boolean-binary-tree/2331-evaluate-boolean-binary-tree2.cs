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
    public TreeNode RemoveLeafNodes(TreeNode root, int target) {
        return DeleteNode(root, target);
    }

    private TreeNode DeleteNode(TreeNode root, int target) {
        if (root == null) {
            return null;
        }
        root.left = DeleteNode(root.left, target);
        root.right = DeleteNode(root.right, target);

        if (root.left == null && root.right == null && root.val == target) {
            return null;
        }
        return root;
    }
}