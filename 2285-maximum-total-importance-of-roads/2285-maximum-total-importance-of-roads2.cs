using System;

public class Solution {
    public long MaximumImportance(int n, int[][] roads) {
        long[] degree = new long[n];
        foreach (var road in roads) {
            degree[road[0]]++;
            degree[road[1]]++;
        }
        long[][] citiesWithDegrees = new long[n][];
        for (int i = 0; i < n; i++) {
            citiesWithDegrees[i] = new long[] { i, degree[i] };
        }
        Array.Sort(citiesWithDegrees, (a, b) => b[1].CompareTo(a[1]));
        long[] values = new long[n];
        for (int i = 0; i < n; i++) {
            values[citiesWithDegrees[i][0]] = n - i;
        }
        long totalImportance = 0;
        foreach (var road in roads) {
            totalImportance += values[road[0]] + values[road[1]];
        }
        return totalImportance;
    }
}