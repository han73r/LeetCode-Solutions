
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
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder) {
        Dictionary<int, int> postIndexMap = new Dictionary<int, int>();
        for (int i = 0; i < postorder.Length; i++)
            postIndexMap[postorder[i]] = i;
        return BuildTree(preorder, postorder, 0, 0, preorder.Length, postIndexMap);
    }
    private TreeNode BuildTree(int[] preorder, int[] postorder, int preStart, int postStart, int length, Dictionary<int, int> postIndexMap) {
        if (length == 0) return null;
        TreeNode root = new TreeNode(preorder[preStart]);
        if (length == 1) return root;
        int leftChildValue = preorder[preStart + 1];
        int leftChildIndexInPost = postIndexMap[leftChildValue];
        int leftSubtreeSize = leftChildIndexInPost - postStart + 1;
        root.left = BuildTree(preorder, postorder, preStart + 1, postStart, leftSubtreeSize, postIndexMap);
        root.right = BuildTree(preorder, postorder, preStart + 1 + leftSubtreeSize, postStart + leftSubtreeSize, length - 1 - leftSubtreeSize, postIndexMap);
        return root;
    }
}