using System.Collections.Generic;

public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        if (n == 1) return new List<int>() { 0 };

        List<HashSet<int>> adjList = new();
        for (int i = 0; i < n; i++) {
            adjList.Add(new HashSet<int>());
        }
        foreach (var edge in edges) {
            int u = edge[0];
            int v = edge[1];
            adjList[u].Add(v);
            adjList[v].Add(u);
        }

        List<int> leaves = new List<int>();
        for (int i = 0; i < n; i++) {
            if (adjList[i].Count == 1) {
                leaves.Add(i);
            }
        }

        while (n > 2) {
            n -= leaves.Count;
            List<int> newLeaves = new List<int>();
            foreach (var leaf in leaves) {
                int neighbor = adjList[leaf].First();
                adjList[neighbor].Remove(leaf);
                if (adjList[neighbor].Count == 1) {
                    newLeaves.Add(neighbor);
                }
            }
            leaves = newLeaves;
        }
        return leaves;
    }
}