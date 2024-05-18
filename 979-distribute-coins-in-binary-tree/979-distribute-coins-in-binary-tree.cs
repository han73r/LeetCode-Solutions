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
public class Solution {
    int totalMoves = 0;
    public int DistributeCoins(TreeNode root) {
        CalculateExcess(root);
        return totalMoves;
    }

    private int CalculateExcess(TreeNode node) {
        if (node == null) return 0;
        int leftExcess = CalculateExcess(node.left);
        int rightExcess = CalculateExcess(node.right);
        int nodeExcess = node.val + leftExcess + rightExcess - 1;
        totalMoves += Math.Abs(nodeExcess);
        return nodeExcess;
    }
}