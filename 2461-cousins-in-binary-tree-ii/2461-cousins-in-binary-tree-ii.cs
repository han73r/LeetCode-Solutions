
using System.Collections.Generic;

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
    private List<int> depthSum;
    public TreeNode ReplaceValueInTree(TreeNode root) {
        depthSum = new List<int>();
        DFS1(root, 0);
        DFS2(root, 0, 0);
        return root;
    }
    private void DFS1(TreeNode root, int d) {
        if (root == null) return;
        if (d >= depthSum.Count) {
            depthSum.Add(root.val);
        } else {
            depthSum[d] += root.val;
        }
        DFS1(root.left, d + 1);
        DFS1(root.right, d + 1);
    }
    private void DFS2(TreeNode root, int val, int d) {
        if (root == null) return;
        root.val = val;
        int c = d + 1 < depthSum.Count ? depthSum[d + 1] : 0;
        c -= (root.left != null ? root.left.val : 0);
        c -= (root.right != null ? root.right.val : 0);
        if (root.left != null) DFS2(root.left, c, d + 1);
        if (root.right != null) DFS2(root.right, c, d + 1);
    }
}