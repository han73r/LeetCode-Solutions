public class Solution {
    private int n;
    private const int INF = 1_000_000_000;
    private int[,] cost;
    private int[,] memo;

    private int GetCost(string s, int l, int r) {
        int len = r - l + 1;
        int best = INF;

        for (int d = 1; d < len; d++) {
            if (len % d != 0) continue;

            int changes = 0;

            for (int offset = 0; offset < d; offset++) {
                int left = l + offset;
                int right = r - d + 1 + offset;

                while (left < right) {
                    if (s[left] != s[right])
                        changes++;

                    left += d;
                    right -= d;
                }
            }

            best = Math.Min(best, changes);
        }

        return best;
    }

    private int Dfs(string s, int start, int k) {
        if (k == 0)
            return start == n ? 0 : INF;

        if (n - start < 2 * k)
            return INF;

        if (memo[start, k] != -1)
            return memo[start, k];

        int ans = INF;

        for (int end = start + 2; end <= n - 2 * (k - 1); end++) {
            ans = Math.Min(ans,
                cost[start, end - 1] + Dfs(s, end, k - 1));
        }

        return memo[start, k] = ans;
    }

    public int MinimumChanges(string s, int k) {
        n = s.Length;

        cost = new int[n, n];
        memo = new int[n, k + 1];

        for (int i = 0; i < n; i++) {
            for (int j = 0; j <= k; j++)
                memo[i, j] = -1;
        }

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                cost[i, j] = GetCost(s, i, j);
            }
        }

        return Dfs(s, 0, k);
    }
}
