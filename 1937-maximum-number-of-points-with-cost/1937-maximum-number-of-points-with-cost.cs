using System;

public class Solution {
    public long MaxPoints(int[][] points) {
        int m = points.Length;
        int n = points[0].Length;
        long[] prevRow = new long[n];
        for (int i = 0; i < n; i++) {
            prevRow[i] = points[0][i];
        }
        for (int r = 1; r < m; r++) {
            long[] left = new long[n];
            long[] right = new long[n];
            long[] currRow = new long[n];
            left[0] = prevRow[0];
            for (int c = 1; c < n; c++) {
                left[c] = Math.Max(left[c - 1] - 1, prevRow[c]);
            }
            right[n - 1] = prevRow[n - 1];
            for (int c = n - 2; c >= 0; c--) {
                right[c] = Math.Max(right[c + 1] - 1, prevRow[c]);
            }
            for (int c = 0; c < n; c++) {
                currRow[c] = points[r][c] + Math.Max(left[c], right[c]);
            }
            prevRow = currRow;
        }
        long maxPoints = 0;
        for (int i = 0; i < n; i++) {
            maxPoints = Math.Max(maxPoints, prevRow[i]);
        }
        return maxPoints;
    }
}