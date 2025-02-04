using System;

public class Solution {
    public int MaxAscendingSum(int[] nums) {
        int n = nums.Length;
        int[] dp = new int[n];
        dp[0] = nums[0];
        int maxSum = dp[0];
        for (int i = 1; i < n; i++) {
            if (nums[i] > nums[i - 1])
                dp[i] = dp[i - 1] + nums[i];
            else
                dp[i] = nums[i];
            maxSum = Math.Max(maxSum, dp[i]);
        }
        return maxSum;
    }
}