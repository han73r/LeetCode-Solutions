public class Solution {
    public int IslandPerimeter(int[][] grid) {
        int c = grid.Length;
        int r = grid[0].Length;
        int[][] dp = new int[c][];
        for (int i = 0; i < c; i++) {
            dp[i] = new int[r];
            for (int j = 0; j < r; j++) {
                if (grid[i][j] == 1) {
                    dp[i][j] = 4;
                    if (i > 0 && grid[i - 1][j] == 1)
                        dp[i][j] -= 2;
                    if (j > 0 && grid[i][j - 1] == 1)
                        dp[i][j] -= 2;
                }
            }
        }
        int perimeter = 0;
        for (int i = 0; i < c; i++) {
            for (int j = 0; j < r; j++) {
                perimeter += dp[i][j];
            }
        }
        return perimeter;
    }
}