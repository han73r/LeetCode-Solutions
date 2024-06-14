using System;

public class Solution {
    public int MinIncrementForUnique(int[] nums) {
        if (nums.Length == 0) return 0;
        Array.Sort(nums);
        int increments = 0;
        int prev = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] <= prev) {
                increments += prev + 1 - nums[i];
                prev = prev + 1;
            } else {
                prev = nums[i];
            }
        }
        return increments;
    }
}