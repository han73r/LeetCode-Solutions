using System;

public class Solution {
    public int CherryPickup(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;

        // Initialize dp array to store the maximum cherries collected
        int[][][] dp = new int[m][][];
        for (int i = 0; i < m; i++) {
            dp[i] = new int[n][];
            for (int j = 0; j < n; j++) {
                dp[i][j] = new int[n];
            }
        }

        // Fill the dp array from the bottom row to the top row
        for (int r = m - 1; r >= 0; r--) {
            for (int c1 = 0; c1 < n; c1++) {
                for (int c2 = 0; c2 < n; c2++) {
                    // Current cell cherries collected
                    int cherries = grid[r][c1];
                    if (c1 != c2) {
                        cherries += grid[r][c2];
                    }

                    // Transition to the next row
                    if (r != m - 1) {
                        int max_cherries = 0;
                        for (int nc1 = c1 - 1; nc1 <= c1 + 1; nc1++) {
                            for (int nc2 = c2 - 1; nc2 <= c2 + 1; nc2++) {
                                if (nc1 >= 0 && nc1 < n && nc2 >= 0 && nc2 < n) {
                                    max_cherries = Math.Max(max_cherries, dp[r + 1][nc1][nc2]);
                                }
                            }
                        }
                        cherries += max_cherries;
                    }
                    dp[r][c1][c2] = cherries;
                }
            }
        }
        return dp[0][0][n - 1];
    }
}