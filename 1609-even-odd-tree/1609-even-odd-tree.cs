
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
    public bool IsEvenOddTree(TreeNode root) {
        if (root == null) return true;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int level = 0;

        while (queue.Count > 0) {
            int size = queue.Count;
            int prevValue = level % 2 == 0 ? int.MinValue : int.MaxValue;

            for (int i = 0; i < size; i++) {
                TreeNode node = queue.Dequeue();

                if (level % 2 == 0) { // Even level
                    if (node.val % 2 == 0 || node.val <= prevValue) return false;
                } else { // Odd level
                    if (node.val % 2 != 0 || node.val >= prevValue) return false;
                }

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);

                prevValue = node.val;
            }

            level++;
        }

        return true;
    }
}