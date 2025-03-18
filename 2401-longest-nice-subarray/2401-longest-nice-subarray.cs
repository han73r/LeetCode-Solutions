using System;

public class Solution {
    public int LongestNiceSubarray(int[] nums) {
        int n = nums.Length;
        int maxLength = 1;
        int left = 0;
        int usedBits = 0;
        for (int right = 0; right < n; right++) {
            while ((usedBits & nums[right]) != 0) {
                usedBits ^= nums[left];
                left++;
            }
            usedBits |= nums[right];
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        return maxLength;
    }
}