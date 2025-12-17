public class Solution {
    public long MaximumProfit(int[] prices, int k) {
        int n = prices.Length;
        long[,,] dp = new long [n + 1, k + 1, 3];
        return DP(0, k, 0, prices, dp);
    }
    long DP(int position, int k, int taken, int[] prices, long[, ,] dp) { 
        if (k == 0) 
            return 0;  
        if (position == prices.Length - 1) 
            return taken == 0 ? 0 : (taken == 1 ? prices[position] : -1 * prices[position]);
        if (dp[position, k, taken] != 0)
            return dp[position, k, taken];
        long resSkip = DP(position + 1, k, taken, prices, dp);
        
        if (taken == 1) {
            long sell = prices[position] + DP(position + 1, k - 1, 0, prices, dp);
            dp[position, k, taken] = Math.Max(resSkip, sell);
            return dp[position, k, taken];
        }
        if (taken == 2) {
            long sell = -prices[position] + DP(position + 1, k - 1, 0, prices, dp);
            dp[position, k, taken] = Math.Max(resSkip, sell);
            return dp[position, k, taken];
        }

        long buy = -1 * prices[position] + DP(position + 1, k, 1, prices, dp);
        long shortSell = prices[position] + DP(position + 1, k, 2, prices, dp);
        dp[position, k, taken] = Math.Max(resSkip, Math.Max(buy, shortSell));
        return dp[position, k, taken];
    }
}
