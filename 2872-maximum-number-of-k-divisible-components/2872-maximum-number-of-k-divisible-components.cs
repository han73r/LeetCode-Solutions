using System.Collections.Generic;

public class Solution {
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k) {
        List<int>[] graph = new List<int>[n];
        foreach (var edge in edges) {
            int node1 = edge[0];
            int node2 = edge[1];
            if (graph[node1] == null)
                graph[node1] = new List<int>();
            if (graph[node2] == null)
                graph[node2] = new List<int>();
            graph[node1].Add(node2);
            graph[node2].Add(node1);
        }
        int KDivisableComponentCount = 0;
        DFS(0, -1);
        return KDivisableComponentCount;
        long DFS(int currentNode, int parentNode) {
            long SubTreeSum = values[currentNode];
            if (graph[currentNode] != null) {
                foreach (var neighbor in graph[currentNode]) {
                    //avoid the cycle
                    if (neighbor != parentNode)
                        SubTreeSum = SubTreeSum + DFS(neighbor, currentNode);
                }
            }
            if (SubTreeSum % k == 0) {
                KDivisableComponentCount++;
            }
            return SubTreeSum;
        }
    }
}