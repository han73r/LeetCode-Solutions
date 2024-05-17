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
        DeleteNode(root, target);
        if (root.left == null && root.right == null && root.val == target) {
            return null;
        }
        return root;
    }

    private bool DeleteNode(TreeNode root, int target) {
        if (root.left == null && root.right == null) {
            if (root.val == target) {
                return true;
            } else {
                return false;
            }
        }
        if (root.left != null) {
            if (DeleteNode(root.left, target)) {
                root.left = null;
            }
        }

        if (root.right != null) {
            if (DeleteNode(root.right, target)) {
                root.right = null;
            }
        }
        if (root.left == null && root.right == null) {
            if (root.val == target) {
                return true;
            } else {
                return false;
            }
        }
        return false;
    }
}