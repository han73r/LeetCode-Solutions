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
    private int leftMostValue;
    private int maxDepth;
    public int FindBottomLeftValue(TreeNode root) {
        leftMostValue = root.val;
        maxDepth = 0;
        DFS(root, 0);
        return leftMostValue;
    }

    private void DFS(TreeNode node, int depth) {
        if (node == null) return;

        if (depth > maxDepth) {
            leftMostValue = node.val;
            maxDepth = depth;
        }
        DFS(node.left, depth + 1);
        DFS(node.right, depth + 1);
    }
}