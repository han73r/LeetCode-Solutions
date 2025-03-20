using System;

public class Solution {
    public int[] MinimumCost(int n, int[][] edges, int[][] query) {
        int[] parent = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
        }

        int[] minPathCost = new int[n];
        Array.Fill(minPathCost, -1);

        int FindRoot(int node) {
            if (parent[node] != node) {
                parent[node] = FindRoot(parent[node]);
            }
            return parent[node];
        }

        foreach (var edge in edges) {
            int source = edge[0], target = edge[1], weight = edge[2];
            int sourceRoot = FindRoot(source);
            int targetRoot = FindRoot(target);

            minPathCost[targetRoot] &= weight;

            if (sourceRoot != targetRoot) {
                minPathCost[targetRoot] &= minPathCost[sourceRoot];
                parent[sourceRoot] = targetRoot;
            }
        }

        int[] result = new int[query.Length];

        for (int i = 0; i < query.Length; i++) {
            int start = query[i][0], end = query[i][1];

            if (start == end) result[i] = 0;
            else if (FindRoot(start) != FindRoot(end)) result[i] = -1;
            else result[i] = minPathCost[FindRoot(start)];
        }

        return result;
    }
}