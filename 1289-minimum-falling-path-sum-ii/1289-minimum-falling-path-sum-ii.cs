using System;

public class Solution {
    public int MinFallingPathSum(int[][] grid) {
        int n = grid.Length;
        for (int i = 1; i < n; i++) {
            for (int j = 0; j < n; j++) {
                int minPrevSum = int.MaxValue;
                for (int k = 0; k < n; k++) {
                    if (k != j) {
                        minPrevSum = Math.Min(minPrevSum, grid[i - 1][k]);
                    }
                }
                grid[i][j] += minPrevSum;
            }
        }
        int minSum = int.MaxValue;
        foreach (int num in grid[n - 1]) {
            minSum = Math.Min(minSum, num);
        }
        return minSum;
    }
}