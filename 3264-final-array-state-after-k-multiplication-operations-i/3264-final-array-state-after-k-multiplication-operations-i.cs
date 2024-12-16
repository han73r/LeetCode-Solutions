using System.Linq;
using System;

public class Solution {
    public int[] GetFinalState(int[] nums, int k, int multiplier) {
        int minValue = 0;
        int valueIndex = 0;
        while (k > 0) {
            minValue = nums.Min();
            valueIndex = Array.IndexOf(nums, minValue);
            nums[valueIndex] = minValue * multiplier;
            k--;
        }
        return nums;
    }
}