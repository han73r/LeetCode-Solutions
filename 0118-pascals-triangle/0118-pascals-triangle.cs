using System.Collections.Generic;

public class Solution {
    private static List<List<int>> dp = new List<List<int>> {
        new List<int> {1},
        new List<int> {1, 1}
    };
    public IList<IList<int>> Generate(int numRows) {
        if (dp.Count < numRows) {
            for (int i = dp.Count + 1; i <= numRows; i++) {
                dp.Add(new List<int>());
                dp[i - 1].Add(1);
                int j = 1;
                while (j <= i - 2) {
                    dp[i - 1].Add(dp[i - 2][j - 1] + dp[i - 2][j]);
                    j++;
                }
                dp[i - 1].Add(1);
            }
        }
        return dp.Take(numRows).Cast<IList<int>>().ToList();
    }
}