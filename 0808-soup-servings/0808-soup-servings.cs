public class Solution {
    private double[,] memo;
    public double SoupServings(int n) {
        if (n >= 4800) return 1.0;

        int N = (n + 24) / 25;
        memo = new double[N + 1, N + 1];
        for (int i = 0; i <= N; i++)
            for (int j = 0; j <= N; j++)
                memo[i, j] = -1.0;

        return Dfs(N, N);
    }
    private double Dfs(int a, int b) {
        if (a <= 0 && b <= 0) return 0.5;
        if (a <= 0) return 1.0;
        if (b <= 0) return 0.0;
        if (memo[a, b] != -1.0) return memo[a, b];

        double res = 0.0;
        res += Dfs(a - 4, b);
        res += Dfs(a - 3, b - 1);
        res += Dfs(a - 2, b - 2);
        res += Dfs(a - 1, b - 3);
        res *= 0.25;

        memo[a, b] = res;
        return res;
    }
}