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
    public TreeNode AddOneRow(TreeNode root, int val, int depth) {
        if (depth == 1) {
            TreeNode newRoot = new TreeNode(val);
            newRoot.left = root;
            return newRoot;
        }
        DFS(root, val, depth, 1);
        return root;
    }
    private void DFS(TreeNode node, int val, int depth, int currentDepth) {
        if (node == null) return;
        if (currentDepth == depth - 1) {
            // Добавляем новые узлы на нужной глубине
            TreeNode left = new TreeNode(val);
            left.left = node.left;
            node.left = left;

            TreeNode right = new TreeNode(val);
            right.right = node.right;
            node.right = right;
            return;
        }
        // Рекурсивно вызываем DFS для левого и правого потомков
        DFS(node.left, val, depth, currentDepth + 1);
        DFS(node.right, val, depth, currentDepth + 1);
    }
}