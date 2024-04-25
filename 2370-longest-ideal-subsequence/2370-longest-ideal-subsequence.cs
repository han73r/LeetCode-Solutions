using System;

public class Solution {
    public int LongestIdealString(string s, int k) {
        int n = s.Length;
        int[] dp = new int[26];
        int maxLen = 0;
        for (int i = 0; i < n; i++) {
            char curr = s[i];
            int idx = curr - 'a';
            int best = 0;
            for (int prev = 0; prev < 26; prev++) {
                if (Math.Abs(curr - 'a' - prev) <= k) {
                    best = Math.Max(best, dp[prev]);
                }
            }
            dp[idx] = best + 1;
            maxLen = Math.Max(maxLen, dp[idx]);
        }
        return maxLen;
    }
}