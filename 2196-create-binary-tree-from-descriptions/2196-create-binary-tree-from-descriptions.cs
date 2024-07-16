
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
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        Dictionary<int, TreeNode> nodes = new Dictionary<int, TreeNode>();
        HashSet<int> children = new HashSet<int>();
        // Step 1: Build the tree nodes and record all children
        foreach (var desc in descriptions) {
            int parentVal = desc[0];
            int childVal = desc[1];
            bool isLeft = desc[2] == 1;
            if (!nodes.ContainsKey(parentVal)) {
                nodes[parentVal] = new TreeNode(parentVal);
            }
            if (!nodes.ContainsKey(childVal)) {
                nodes[childVal] = new TreeNode(childVal);
            }
            if (isLeft) {
                nodes[parentVal].left = nodes[childVal];
            } else {
                nodes[parentVal].right = nodes[childVal];
            }
            children.Add(childVal);
        }
        // Step 2: Find the root (the node that is not any child's value)
        foreach (var desc in descriptions) {
            int parentVal = desc[0];
            if (!children.Contains(parentVal)) {
                return nodes[parentVal];
            }
        }
        return null;
    }
}