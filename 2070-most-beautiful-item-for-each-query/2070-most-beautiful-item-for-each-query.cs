using System.Collections.Generic;
using System.Linq;
using System;

public class Solution {
    public int[] MaximumBeauty(int[][] items, int[] queries) {
        Array.Sort(items, (a, b) => a[0].CompareTo(b[0]));
        int n = items.Length;

        int[] maxBeautyUpToPrice = new int[n];
        maxBeautyUpToPrice[0] = items[0][1];
        for (int i = 1; i < n; i++) {
            maxBeautyUpToPrice[i] = Math.Max(maxBeautyUpToPrice[i - 1], items[i][1]);
        }
        int[] sortedQueries = queries.ToArray();
        Array.Sort(sortedQueries);
        Dictionary<int, int> queryResults = new Dictionary<int, int>();
        int j = 0;
        foreach (var q in sortedQueries) {
            while (j < n && items[j][0] <= q) j++;
            queryResults[q] = j > 0 ? maxBeautyUpToPrice[j - 1] : 0;
        }
        int[] result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            result[i] = queryResults[queries[i]];
        }
        return result;
    }
}