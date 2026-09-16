public class Solution {
    private const int Mod = 1_000_000_007;
    public int NumberOfSets(int n, int k) {
        int[] dp = new int[n];
        int[] prefixSums = new int[n + 1];

        for (int j = 0; j < n; j++) {
            dp[j] = 1;
            prefixSums[j + 1] = (prefixSums[j] + dp[j]) % Mod;
        }

        for (int i = 1; i <= k; i++) {
            dp[0] = 0;
            for (int j = 1; j < n; j++)
                dp[j] = (dp[j - 1] + prefixSums[j]) % Mod;
            for (int j = 0; j < n; j++)
                prefixSums[j + 1] = (prefixSums[j] + dp[j]) % Mod;
        }

        return dp[n - 1];
    }
}
