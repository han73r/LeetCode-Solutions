
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
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> result = new List<int>();
        PostorderHelper(root, result);
        return result;
    }
    private void PostorderHelper(TreeNode node, List<int> result) {
        if (node == null) return;
        PostorderHelper(node.left, result);
        PostorderHelper(node.right, result);
        result.Add(node.val);
    }
}