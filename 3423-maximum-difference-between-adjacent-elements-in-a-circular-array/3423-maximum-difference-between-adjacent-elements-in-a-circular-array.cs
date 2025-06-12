using System.Linq;
using System;

public class Solution {
    public int MaxAdjacentDistance(int[] nums) {
        int n = nums.Count();
        int maximum = Math.Abs(nums[0] - nums[n - 1]);
        for (int i = 0; i < n - 1; i++)
            maximum = Math.Max(maximum, Math.Abs(nums[i] - nums[i + 1]));

        return maximum;
    }
}