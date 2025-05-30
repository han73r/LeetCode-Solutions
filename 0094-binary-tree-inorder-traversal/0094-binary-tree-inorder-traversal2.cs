using System.Collections.Generic;
public class Solution {
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> result = new();
        DFS(root, result);
        return result;
    }

    private void DFS(TreeNode node, List<int> result) {
        if (node == null) return;
        DFS(node.left, result);
        result.Add(node.val);
        DFS(node.right, result);
    }
}