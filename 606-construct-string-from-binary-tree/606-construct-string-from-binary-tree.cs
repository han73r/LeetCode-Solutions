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
public class Solution
{
    public string Tree2str(TreeNode root)
    {
        StringBuilder stringBuilder = new();
        return InOrderTraversalHelper(root, stringBuilder).ToString();
    }

    private StringBuilder InOrderTraversalHelper(TreeNode node, StringBuilder stringBuilder)
    {
        if (node == null) return stringBuilder;

        stringBuilder.Append(node.val);

        if (node.left != null || node.right != null)
        {
            stringBuilder.Append('(');
            InOrderTraversalHelper(node.left, stringBuilder);
            stringBuilder.Append(')');
        }

        if (node.right != null)
        {
            stringBuilder.Append('(');
            InOrderTraversalHelper(node.right, stringBuilder);
            stringBuilder.Append(')');
        }

        return stringBuilder;
    }
}