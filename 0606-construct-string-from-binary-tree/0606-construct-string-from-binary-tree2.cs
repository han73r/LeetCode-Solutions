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
        if (root == null) return "";

        StringBuilder result = new StringBuilder();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        HashSet<TreeNode> visited = new HashSet<TreeNode>();

        stack.Push(root);

        while (stack.Count > 0)
        {
            TreeNode current = stack.Peek();

            if (visited.Contains(current))
            {
                stack.Pop();
                result.Append(')');
            }
            else
            {
                visited.Add(current);
                result.Append('(').Append(current.val);

                if (current.right != null)
                    stack.Push(current.right);

                if (current.left != null)
                    stack.Push(current.left);
                else if (current.right != null)
                    result.Append("()");
            }
        }
        return result.ToString().Substring(1, result.Length - 2);
    }
}