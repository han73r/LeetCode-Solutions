using System.Collections.Generic;

public class Solution {
    private List<List<int>> graph;
    private int[] count;
    private int[] ans;
    public int[] SumOfDistancesInTree(int n, int[][] edges) {
        graph = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            graph.Add(new List<int>());
        }
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }
        count = new int[n];
        ans = new int[n];
        DFS(0, -1);
        DFS2(0, -1);
        return ans;
    }

    private void DFS(int node, int parent) {
        count[node] = 1;
        foreach (var neighbor in graph[node]) {
            if (neighbor != parent) {
                DFS(neighbor, node);
                count[node] += count[neighbor];
                ans[node] += ans[neighbor] + count[neighbor];
            }
        }
    }

    private void DFS2(int node, int parent) {
        foreach (var neighbor in graph[node]) {
            if (neighbor != parent) {
                ans[neighbor] = ans[node] - count[neighbor] + (count.Length - count[neighbor]);
                DFS2(neighbor, node);
            }
        }
    }
}