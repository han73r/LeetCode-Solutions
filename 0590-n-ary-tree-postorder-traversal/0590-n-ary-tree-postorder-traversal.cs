using System.Collections.Generic;

public class Solution {
    public IList<int> Postorder(Node root) {
        List<int> result = new List<int>();
        PostorderHelper(root, result);
        return result;
    }
    private void PostorderHelper(Node node, List<int> result) {
        if (node == null) return;
        foreach (var child in node.children) {
            PostorderHelper(child, result);
        }
        result.Add(node.val);
    }
}