using System;

public class Solution {
    public long CountSubarrays(int[] nums, int minK, int maxK) {
        int length = nums.Length;
        long result = 0;
        int lastIndex = -1, right = -1, left = -1;
        for (int i = 0; i < length; ++i) {
            if (!(minK <= nums[i] && nums[i] <= maxK)) {
                lastIndex = i;
            }
            if (nums[i] == minK) {
                left = i;
            }
            if (nums[i] == maxK) {
                right = i;
            }
            result += Math.Max(0, Math.Min(left, right) - lastIndex);
        }
        return result;
    }
}