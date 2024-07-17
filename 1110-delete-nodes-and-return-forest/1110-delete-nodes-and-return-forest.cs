
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
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        HashSet<int> toDeleteSet = new HashSet<int>(to_delete);
        List<TreeNode> result = new List<TreeNode>();
        ProcessNode(root, true, toDeleteSet, result);
        return result;
    }

    private TreeNode ProcessNode(TreeNode node, bool isRoot, HashSet<int> toDeleteSet, List<TreeNode> result) {
        if (node == null) return null;
        bool toDelete = toDeleteSet.Contains(node.val);
        if (isRoot && !toDelete) {
            result.Add(node);
        }
        node.left = ProcessNode(node.left, toDelete, toDeleteSet, result);
        node.right = ProcessNode(node.right, toDelete, toDeleteSet, result);
        return toDelete ? null : node;
    }
}