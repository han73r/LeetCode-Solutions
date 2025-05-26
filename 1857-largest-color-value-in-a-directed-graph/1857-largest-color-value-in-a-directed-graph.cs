using System.Collections.Generic;
using System;

public class Solution {
    public int LargestPathValue(string colors, int[][] edges) {
        int n = colors.Length;
        List<int>[] graph = new List<int>[n];
        int[] inDegree = new int[n];

        for (int i = 0; i < n; i++) {
            graph[i] = new List<int>();
        }

        foreach (var edge in edges) {
            graph[edge[0]].Add(edge[1]);
            inDegree[edge[1]]++;
        }

        // Create a queue for topological sort
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < n; i++) {
            if (inDegree[i] == 0) queue.Enqueue(i);
        }

        int[,] count = new int[n, 26];  // count[node, colorIndex]
        int visited = 0;
        int result = 0;

        while (queue.Count > 0) {
            int node = queue.Dequeue();
            visited++;
            int colorIndex = colors[node] - 'a';
            count[node, colorIndex]++;
            result = Math.Max(result, count[node, colorIndex]);

            foreach (int neighbor in graph[node]) {
                for (int i = 0; i < 26; i++) {
                    count[neighbor, i] = Math.Max(count[neighbor, i], count[node, i]);
                }

                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) queue.Enqueue(neighbor);
            }
        }

        return visited == n ? result : -1;
    }
}