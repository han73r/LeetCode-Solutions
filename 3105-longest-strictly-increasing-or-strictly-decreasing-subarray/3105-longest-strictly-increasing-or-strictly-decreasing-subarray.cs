using System;

public class Solution {
    public int LongestMonotonicSubarray(int[] nums) {
        int length = nums.Length;
        if (length == 1) return 1;
        int longestSubarray = 1;
        int increasingSubarray = 1, decreasingSubarray = 1;
        for (int i = 1; i < length; i++) {
            if (nums[i] > nums[i - 1]) {
                increasingSubarray++;
                decreasingSubarray = 1;
            } else if (nums[i] < nums[i - 1]) {
                increasingSubarray = 1;
                decreasingSubarray++;
            } else {
                increasingSubarray = 1;
                decreasingSubarray = 1;
            }
            longestSubarray = Math.Max(longestSubarray, Math.Max(increasingSubarray, decreasingSubarray));
        }
        return longestSubarray;
    }
}