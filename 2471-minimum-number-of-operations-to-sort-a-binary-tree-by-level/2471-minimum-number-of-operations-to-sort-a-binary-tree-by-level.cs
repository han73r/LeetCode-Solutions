
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
    public int MinimumOperations(TreeNode root) {
        if (root == null) return 0;

        // Perform BFS to group the tree nodes level by level
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int totalSwaps = 0;

        while (queue.Count > 0) {
            int levelSize = queue.Count;
            List<int> levelValues = new List<int>();

            // Collect all node values for the current level
            for (int i = 0; i < levelSize; i++) {
                TreeNode node = queue.Dequeue();
                levelValues.Add(node.val);

                // Add child nodes to the queue for the next level
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            // Count minimum swaps needed to sort the current level
            totalSwaps += MinimumSwapsToSort(levelValues);
        }

        return totalSwaps;
    }

    private int MinimumSwapsToSort(List<int> values) {
        int n = values.Count;
        int swaps = 0;

        // Create a list of value-index pairs and sort it based on the values
        List<(int value, int index)> sorted = new List<(int value, int index)>();
        for (int i = 0; i < n; i++) {
            sorted.Add((values[i], i));
        }
        sorted.Sort((a, b) => a.value.CompareTo(b.value));

        // Create a visited array to track processed elements
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++) {
            // If the element is already visited or is in the correct position, skip it
            if (visited[i] || sorted[i].index == i) continue;

            // Calculate the size of the cycle
            int cycleSize = 0;
            int j = i;

            while (!visited[j]) {
                visited[j] = true;
                j = sorted[j].index;
                cycleSize++;
            }

            // If there is a cycle of size k, we need (k - 1) swaps
            if (cycleSize > 1) {
                swaps += (cycleSize - 1);
            }
        }
        return swaps;
    }
}