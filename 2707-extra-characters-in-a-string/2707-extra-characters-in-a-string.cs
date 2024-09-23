using System.Collections.Generic;
using System;

public class Solution {
    public int MinExtraChar(string s, string[] dictionary) {
        int n = s.Length;
        HashSet<string> dict = new HashSet<string>(dictionary);
        int[] dp = new int[n + 1];
        for (int i = 0; i <= n; i++) {
            dp[i] = i;
        }
        for (int i = 0; i < n; i++) {
            for (int j = i; j < n; j++) {
                string sub = s.Substring(i, j - i + 1);
                if (dict.Contains(sub)) {
                    dp[j + 1] = Math.Min(dp[j + 1], dp[i]);
                }
            }
            dp[i + 1] = Math.Min(dp[i + 1], dp[i] + 1);
        }
        return dp[n];
    }
}