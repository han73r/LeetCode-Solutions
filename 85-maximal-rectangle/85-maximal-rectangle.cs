using System;

public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return 0;
        int maxArea = 0;
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int[,] dp = new int[rows, cols];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (matrix[i][j] == '1') {
                    dp[i, j] = (j == 0) ? 1 : dp[i, j - 1] + 1;
                    int width = dp[i, j];
                    for (int k = i; k >= 0; k--) {
                        width = Math.Min(width, dp[k, j]);
                        maxArea = Math.Max(maxArea, width * (i - k + 1));
                    }
                }
            }
        }
        return maxArea;
    }
}