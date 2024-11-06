using System;

public class Solution {
    public bool CanSortArray(int[] nums) {
        int prevMax = int.MinValue, currMax = nums[0], currMin = nums[0], setBits = CountBits(nums[0]);
        var l = nums.Length;
        for (int i = 1; i < l; i++) {
            int currentSetBits = CountBits(nums[i]);
            if (setBits == currentSetBits) {
                currMax = Math.Max(currMax, nums[i]);
                currMin = Math.Min(currMin, nums[i]);
            } else {
                if (currMin < prevMax) return false;
                prevMax = currMax;
                setBits = currentSetBits;
                currMin = nums[i];
                currMax = nums[i];
            }
        }
        return currMin > prevMax;
    }
    private int CountBits(int num) {
        return BitOperations.PopCount((uint)num);
    }
}