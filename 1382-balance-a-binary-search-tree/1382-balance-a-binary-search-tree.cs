
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
    public TreeNode BalanceBST(TreeNode root) {
        var set = new SortedSet<int>();
        Traverse(root);
        var sortedArr = set.ToArray();
        return Balance(0, set.Count - 1);
        void Traverse(TreeNode node) {
            if (node == null) return;
            set.Add(node.val);
            Traverse(node.right);
            Traverse(node.left);
        }
        TreeNode Balance(int i, int j) {
            if (i > j) return null;
            var mid = i + (j - i) / 2;
            return new TreeNode(sortedArr[mid], Balance(i, mid - 1),
                Balance(mid + 1, j));
        }
    }
}