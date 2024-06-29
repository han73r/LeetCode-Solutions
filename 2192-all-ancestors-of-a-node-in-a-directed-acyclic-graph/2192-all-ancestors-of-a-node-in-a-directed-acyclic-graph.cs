using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> GetAncestors(int n, int[][] edges) {
        var result = new List<IList<int>>();
        var ancestors = EmptyList(n);
        var adjencyList = FillAdjencyList(EmptyList(n), edges);
        for (int i = 0; i < n; i++) {
            bool[] visited = new bool[n];
            DFS(i, adjencyList, ancestors[i], visited);
            ancestors[i].Sort();
        }
        foreach (var anc in ancestors) {
            result.Add(anc);
        }
        return result;
    }
    private List<int>[] FillAdjencyList(List<int>[] adjencyList, int[][] edges) {
        foreach (var edge in edges) {
            int from = edge[0];
            int to = edge[1];
            adjencyList[to].Add(from);
        }
        return adjencyList;
    }
    private List<int>[] EmptyList(int n) {
        List<int>[] emptyList = new List<int>[n];
        for (int i = 0; i < n; i++) {
            emptyList[i] = new List<int>();
        }
        return emptyList;
    }
    private void DFS(int node, List<int>[] adjencyList, List<int> ancestors, bool[] visited) {
        visited[node] = true;
        foreach (var adj in adjencyList[node]) {
            if (!visited[adj]) {
                ancestors.Add(adj);
                DFS(adj, adjencyList, ancestors, visited);
            }
        }
    }
}