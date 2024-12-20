
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
    public TreeNode ReverseOddLevels(TreeNode root) {
        if (root == null) return root;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        bool isOddLevel = false;
        while (queue.Count > 0) {
            int levelSize = queue.Count;
            List<TreeNode> currentLevelNodes = new List<TreeNode>();
            for (int i = 0; i < levelSize; i++) {
                TreeNode node = queue.Dequeue();
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
                currentLevelNodes.Add(node);
            }
            if (isOddLevel) {
                int left = 0, right = currentLevelNodes.Count - 1;
                while (left < right) {
                    int temp = currentLevelNodes[left].val;
                    currentLevelNodes[left].val = currentLevelNodes[right].val;
                    currentLevelNodes[right].val = temp;
                    left++;
                    right--;
                }
            }
            isOddLevel = !isOddLevel;
        }
        return root;
    }
}