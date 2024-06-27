using System.Collections.Generic;

public class Solution {
    public int FindCenter(int[][] edges) {
        Dictionary<int, int> countNumbers = new();
        foreach (var edge in edges) {
            foreach (var vertex in edge) {
                if (countNumbers.ContainsKey(vertex)) {
                    countNumbers[vertex]++;
                } else {
                    countNumbers.Add(vertex, 1);
                }
            }
        }
        return countNumbers.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
    }
}