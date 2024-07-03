using System;

public class Solution {
    public int MinDifference(int[] nums) {
        if (nums.Length < 4) return 0;
        Array.Sort(nums);
        int l = nums.Length;
        int o1 = nums[l - 4] - nums[0];
        int o2 = nums[l - 3] - nums[1];
        int o3 = nums[l - 2] - nums[2];
        int o4 = nums[l - 1] - nums[3];
        return Math.Min(Math.Min(o1, o2), Math.Min(o3, o4));
    }
}