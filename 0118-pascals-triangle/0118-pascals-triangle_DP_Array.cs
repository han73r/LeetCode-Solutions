using System.Collections.Generic;
using System;

public class Solution {
    private static int[][] dp = new int[30][];
    private static int computedRows = 0;
    public IList<IList<int>> Generate(int numRows) {
        for (int i = computedRows; i < numRows; i++) {
            dp[i] = new int[i + 1];
            dp[i][0] = dp[i][i] = 1;
            for (int j = 1; j < i; j++)
                dp[i][j] = dp[i - 1][j - 1] + dp[i - 1][j];
        }
        computedRows = Math.Max(computedRows, numRows);
        var result = new List<IList<int>>(numRows);
        for (int i = 0; i < numRows; i++)
            result.Add(dp[i]);
        return result;
    }
}