using System;

public class Solution {
    public int StrangePrinter(string s) {
        int n = s.Length;
        if (n == 0) return 0;
        int[,] dp = new int[n, n];
        for (int i = n - 1; i >= 0; i--) {
            dp[i, i] = 1;
            for (int j = i + 1; j < n; j++) {
                if (s[i] == s[j]) {
                    dp[i, j] = dp[i, j - 1];
                } else {
                    int minTurns = int.MaxValue;
                    for (int k = i; k < j; k++) {
                        minTurns = Math.Min(minTurns, dp[i, k] + dp[k + 1, j]);
                    }
                    dp[i, j] = minTurns;
                }
            }
        }
        return dp[0, n - 1];
    }
}