using System;

public class Solution {
    private int[,] sparseTable;
    private int[] logValues;

    private int QueryMaximum(int left, int right) {
        int k = logValues[right - left + 1];
        return Math.Max(sparseTable[left, k], sparseTable[right - (1 << k) + 1, k]);
    }

    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries) {
        int n = heights.Length;
        int logMax = 20;
        sparseTable = new int[n, logMax];
        logValues = new int[n + 1];
        logValues[0] = -1;
        for (int i = 1; i <= n; i++) {
            logValues[i] = logValues[i >> 1] + 1;
        }
        for (int i = 0; i < n; i++) {
            sparseTable[i, 0] = heights[i];
        }
        for (int i = 1; i < logMax; i++) {
            for (int j = 0; j + (1 << i) - 1 < n; j++) {
                sparseTable[j, i] = Math.Max(sparseTable[j, i - 1], sparseTable[j + (1 << (i - 1)), i - 1]);
            }
        }
        int numQueries = queries.Length;
        int[] results = new int[numQueries];
        for (int queryIndex = 0; queryIndex < numQueries; queryIndex++) {
            int left = queries[queryIndex][0];
            int right = queries[queryIndex][1];
            if (left > right) {
                (left, right) = (right, left);
            }
            if (left == right) {
                results[queryIndex] = left;
                continue;
            }
            if (heights[right] > heights[left]) {
                results[queryIndex] = right;
                continue;
            }
            int maxHeight = Math.Max(heights[right], heights[left]);
            int low = right, high = n, mid;
            while (low < high) {
                mid = (low + high) >> 1;
                if (QueryMaximum(right, mid) > maxHeight) {
                    high = mid;
                } else {
                    low = mid + 1;
                }
            }
            results[queryIndex] = (low == n) ? -1 : low;
        }
        return results;
    }
}