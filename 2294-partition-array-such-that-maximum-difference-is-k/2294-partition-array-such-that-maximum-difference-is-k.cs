using System;

public class Solution {
    public int PartitionArray(int[] nums, int k) {
        // Sort Array
        int len = nums.Length, cnt = 1, start = 0;
        Array.Sort(nums);
        for (int i = 0; i < len; i++) {
            if (nums[i] - nums[start] > k) {
                cnt++;
                start = i;
            }
        }
        return cnt;
    }
}