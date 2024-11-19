using System.Collections.Generic;
using System;

public class Solution {
    public long MaximumSubarraySum(int[] nums, int k) {
        int n = nums.Length;
        if (n < k) return 0;
        long maxSum = 0, currentSum = 0;
        var set = new HashSet<int>();
        for (int i = 0, j = 0; i < n; i++) {
            while (set.Contains(nums[i])) {
                set.Remove(nums[j]);
                currentSum -= nums[j];
                j++;
            }
            set.Add(nums[i]);
            currentSum += nums[i];
            if (set.Count == k) {
                maxSum = Math.Max(maxSum, currentSum);
                set.Remove(nums[j]);
                currentSum -= nums[j];
                j++;
            }
        }
        return maxSum;
    }
}