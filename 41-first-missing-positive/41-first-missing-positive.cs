using System;

public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int result = 1;
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] > result) {
                return result;
            } else if (nums[i] > 0 && (i == 0 || nums[i] != nums[i - 1])) {
                result++;
            }
        }
        return result;
    }
}