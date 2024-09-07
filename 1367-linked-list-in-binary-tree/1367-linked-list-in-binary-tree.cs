using System.Collections.Generic;

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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
    public bool IsSubPath(ListNode head, TreeNode root) {
        if (root == null) {
            return false;
        }
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            TreeNode currentNode = queue.Dequeue();
            if (currentNode.val == head.val && DfsCheck(currentNode, head)) {
                return true;
            }
            if (currentNode.left != null) {
                queue.Enqueue(currentNode.left);
            }
            if (currentNode.right != null) {
                queue.Enqueue(currentNode.right);
            }
        }

        return false;
    }
    private bool DfsCheck(TreeNode node, ListNode head) {
        if (head == null) {
            return true;
        }
        if (node == null || node.val != head.val) {
            return false;
        }
        return DfsCheck(node.left, head.next) || DfsCheck(node.right, head.next);
    }
}