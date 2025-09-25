using System.Collections.Generic;
using System;

public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        int n = triangle.Count;
        int[] dp = new int[n];
        for (int i = 0; i < n; i++)
            dp[i] = triangle[n - 1][i];
        for (int row = n - 2; row >= 0; row--) {
            for (int i = 0; i <= row; i++)
                dp[i] = Math.Min(dp[i], dp[i + 1]) + triangle[row][i];
        }
        return dp[0];
    }
}