
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
    public string GetDirections(TreeNode root, int startValue, int destValue) {
        List<char> pathToStart = new List<char>();
        List<char> pathToDest = new List<char>();

        // Find paths from root to startValue and destValue
        FindPath(root, startValue, pathToStart);
        FindPath(root, destValue, pathToDest);

        // Find the index of the lowest common ancestor (LCA)
        int i = 0;
        while (i < pathToStart.Count && i < pathToDest.Count && pathToStart[i] == pathToDest[i]) {
            i++;
        }

        // Remove the common path part
        pathToStart = pathToStart.GetRange(i, pathToStart.Count - i);
        pathToDest = pathToDest.GetRange(i, pathToDest.Count - i);

        // Convert path to start to 'U' (up) and add path to destination
        string result = new string('U', pathToStart.Count) + new string(pathToDest.ToArray());
        return result;
    }

    private bool FindPath(TreeNode root, int value, List<char> path) {
        if (root == null) return false;
        if (root.val == value) return true;

        path.Add('L');
        if (FindPath(root.left, value, path)) return true;
        path.RemoveAt(path.Count - 1);

        path.Add('R');
        if (FindPath(root.right, value, path)) return true;
        path.RemoveAt(path.Count - 1);

        return false;
    }
}