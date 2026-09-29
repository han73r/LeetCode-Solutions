public class Solution {
    private static int[,,] dp = new int[101, 101, 201];
    private int m, n;

    private bool Recur(char[][] grid, int i = 0, int j = 0, int cnt = 0) {
        if (i >= m || j >= n)
            return false;

        cnt += grid[i][j] == '(' ? 1 : -1;

        if (cnt < 0)
            return false;

        if (dp[i, j, cnt] != -1)
            return dp[i, j, cnt] == 1;

        if (i == m - 1 && j == n - 1)
            return (dp[i, j, cnt] = cnt == 0 ? 1 : 0) == 1;

        bool ans = Recur(grid, i + 1, j, cnt) ||
                   Recur(grid, i, j + 1, cnt);

        dp[i, j, cnt] = ans ? 1 : 0;
        return ans;
    }

    public bool HasValidPath(char[][] grid) {
        m = grid.Length;
        n = grid[0].Length;

        if ((m + n - 1) % 2 == 1)
            return false;

        for (int i = 0; i < 101; i++)
            for (int j = 0; j < 101; j++)
                for (int k = 0; k < 201; k++)
                    dp[i, j, k] = -1;

        return Recur(grid);
    }
}
