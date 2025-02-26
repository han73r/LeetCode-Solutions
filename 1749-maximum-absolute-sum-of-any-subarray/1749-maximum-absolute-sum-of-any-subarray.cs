using System;

public class Solution {
    public int MaxAbsoluteSum(int[] nums) {
        int minPrefixSum = 0, maxPrefixSum = 0;
        int prefixSum = 0;
        for (int i = 0; i < nums.Length; i++) {
            prefixSum += nums[i];
            minPrefixSum = Math.Min(minPrefixSum, prefixSum);
            maxPrefixSum = Math.Max(maxPrefixSum, prefixSum);
        }
        return maxPrefixSum - minPrefixSum;
    }
}