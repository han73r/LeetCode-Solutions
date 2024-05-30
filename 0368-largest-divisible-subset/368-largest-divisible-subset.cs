using System.Collections.Generic;
using System;

public class Solution {
    public IList<int> LargestDivisibleSubset(int[] nums) {
        int n = nums.Length;
        Array.Sort(nums);
        int[] dp = new int[n];
        for (int i = 0; i < n; i++) {
            dp[i] = 1;
            for (int j = 0; j < i; j++) {
                if (nums[i] % nums[j] == 0) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }
        int maxIndex = 0;
        for (int i = 1; i < n; i++) {
            if (dp[i] > dp[maxIndex]) {
                maxIndex = i;
            }
        }
        List<int> subset = new List<int>();
        int prev = nums[maxIndex];
        int len = dp[maxIndex];
        for (int i = maxIndex; i >= 0; i--) {
            if (prev % nums[i] == 0 && dp[i] == len) {
                subset.Add(nums[i]);
                prev = nums[i];
                len--;
            }
        }
        return subset;
    }
}