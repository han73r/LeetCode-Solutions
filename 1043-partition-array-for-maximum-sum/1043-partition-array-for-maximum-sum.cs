using System;

public class Solution {
    public int MaxSumAfterPartitioning(int[] arr, int k) {
        int n = arr.Length;
        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; i++) {
            int maxVal = 0;
            for (int j = 1; j <= k && i - j >= 0; j++) {
                maxVal = Math.Max(maxVal, arr[i - j]);
                dp[i] = Math.Max(dp[i], dp[i - j] + maxVal * j);
            }
        }
        return dp[n];
    }
}