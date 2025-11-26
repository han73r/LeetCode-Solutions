public class Solution {
    const int MOD = 1_000_000_007;
    public int NumberOfPaths(int[][] grid, int k) {
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] dp = Create2D(n, k);
        int[][] prev = Create2D(n, k);
        for (int i = 0; i < m; i++) {
            var temp = prev;
            prev = dp;
            dp = temp;
            for (int j = 0; j < n; j++)
                Array.Clear(dp[j], 0, k);
            for (int j = 0; j < n; j++) {
                int val = grid[i][j] % k;
                if (i == 0 && j == 0) {
                    dp[0][val] = 1;
                    continue;
                }
                if (i > 0)
                    for (int r = 0; r < k; r++)
                        dp[j][(r + val) % k] = (dp[j][(r + val) % k] + prev[j][r]) % MOD;
                if (j > 0)
                    for (int r = 0; r < k; r++)
                        dp[j][(r + val) % k] = (dp[j][(r + val) % k] + dp[j - 1][r]) % MOD;
            }
        }
        return dp[n - 1][0];
    }
    private int[][] Create2D(int rows, int cols) {
        int[][] arr = new int[rows][];
        for (int i = 0; i < rows; i++)
            arr[i] = new int[cols];
        return arr;
    }
}
