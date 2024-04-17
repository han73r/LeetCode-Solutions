
using System.Text;

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
    private static StringBuilder _current = new();
    private static StringBuilder _smallestString = new();

    public string SmallestFromLeaf(TreeNode root) {
        _current.Clear();
        _smallestString.Clear();
        DFS(root);
        return _smallestString.ToString();
    }

    private void DFS(TreeNode node) {
        if (node == null) return;
        _current.Insert(0, (char)('a' + node.val));
        if (node.left == null && node.right == null) {
            if (_smallestString.Length == 0 || string.Compare(_current.ToString(), _smallestString.ToString()) < 0) {
                _smallestString.Clear().Append(_current);
            }
        }
        DFS(node.left);
        DFS(node.right);
        _current.Remove(0, 1);
    }
}