
using System.Collections.Generic;

using System.Linq;
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
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        List<int> leaves1 = new List<int>();
        List<int> leaves2 = new List<int>();

        CollectLeaves(root1, leaves1);
        CollectLeaves(root2, leaves2);

        return Enumerable.SequenceEqual(leaves1, leaves2);
    }

    private void CollectLeaves(TreeNode root, List<int> leaves)
    {
        if (root == null)
        {
            return;
        }

        if (root.left == null && root.right == null)
        {
            leaves.Add(root.val);
            return;
        }

        CollectLeaves(root.left, leaves);
        CollectLeaves(root.right, leaves);
    }
}