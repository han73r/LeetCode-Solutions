using System.Collections.Generic;
using System;

public class Solution {
    public long MinimumTotalDistance(IList<int> robot, IList<IList<int>> factory) {
        var robots = robot.ToList();
        var factories = factory.ToList();
        robots.Sort();
        factories.Sort((a, b) => a[0].CompareTo(b[0]));
        int m = robots.Count;
        int n = factories.Count;
        long[,] dp = new long[m + 1, n + 1];
        for (int i = 0; i < m; i++) {
            dp[i, n] = long.MaxValue;
        }
        for (int j = n - 1; j >= 0; j--) {
            long prefix = 0;
            var qq = new LinkedList<(int pos, long val)>();
            qq.AddLast((m, 0));
            for (int i = m - 1; i >= 0; i--) {
                prefix += Math.Abs((long)robots[i] - factories[j][0]);

                while (qq.Count > 0 && qq.First.Value.pos > i + factories[j][1]) {
                    qq.RemoveFirst();
                }
                while (qq.Count > 0 && qq.Last.Value.val >= dp[i, j + 1] - prefix) {
                    qq.RemoveLast();
                }
                qq.AddLast((i, dp[i, j + 1] - prefix));
                dp[i, j] = qq.First.Value.val + prefix;
            }
        }
        return dp[0, 0];
    }
}