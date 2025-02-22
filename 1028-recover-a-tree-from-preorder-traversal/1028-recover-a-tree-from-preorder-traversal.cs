
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
    public TreeNode RecoverFromPreorder(string traversal) {
        List<TreeNode> levels = new();
        int i = 0, n = traversal.Length;

        while (i < n) {
            int level = 0;
            while (i < n && traversal[i] == '-') { i++; level++; }
            int val = 0;
            while (i < n && traversal[i] != '-') val = val * 10 + traversal[i++] - '0';
            var node = new TreeNode(val);
            if (level < levels.Count) levels[level] = node; else levels.Add(node);
            if (level > 0) {
                var parent = levels[level - 1];
                if (parent.left != null) parent.right = node;
                else parent.left = node;
            }
        }
        return levels[0];
    }
}