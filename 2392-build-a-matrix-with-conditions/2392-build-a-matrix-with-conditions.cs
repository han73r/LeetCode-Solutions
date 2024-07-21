using System.Collections.Generic;

public class Solution {
    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions) {
        var rowGraph = BuildGraph(k, rowConditions);
        var colGraph = BuildGraph(k, colConditions);
        var rowOrder = TopologicalSort(rowGraph, k);
        var colOrder = TopologicalSort(colGraph, k);
        if (rowOrder == null || colOrder == null) {
            return new int[0][];
        }
        var matrix = new int[k][];
        for (int i = 0; i < k; i++) {
            matrix[i] = new int[k];
        }
        var pos = new int[k + 1];
        for (int i = 0; i < k; i++) {
            pos[rowOrder[i]] = i;
        }
        for (int j = 0; j < k; j++) {
            matrix[pos[colOrder[j]]][j] = colOrder[j];
        }
        return matrix;
    }
    private Dictionary<int, List<int>> BuildGraph(int k, int[][] conditions) {
        var graph = new Dictionary<int, List<int>>();
        for (int i = 1; i <= k; i++) {
            graph[i] = new List<int>();
        }
        foreach (var condition in conditions) {
            graph[condition[0]].Add(condition[1]);
        }
        return graph;
    }
    private List<int> TopologicalSort(Dictionary<int, List<int>> graph, int k) {
        var inDegree = new int[k + 1];
        foreach (var node in graph.Keys) {
            foreach (var neighbor in graph[node]) {
                inDegree[neighbor]++;
            }
        }
        var queue = new Queue<int>();
        for (int i = 1; i <= k; i++) {
            if (inDegree[i] == 0) {
                queue.Enqueue(i);
            }
        }
        var order = new List<int>();
        while (queue.Count > 0) {
            var node = queue.Dequeue();
            order.Add(node);
            foreach (var neighbor in graph[node]) {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) {
                    queue.Enqueue(neighbor);
                }
            }
        }
        return order.Count == k ? order : null;
    }
}