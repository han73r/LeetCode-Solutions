using System;

public class Solution {
    public int MaximumDifference(int[] nums) {
        int result = -1;
        int minSoFar = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] > minSoFar)
                result = Math.Max(result, nums[i] - minSoFar);
            else
                minSoFar = nums[i];
        }
        return result;
    }
}