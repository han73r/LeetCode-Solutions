using System.Collections.Generic;
using System;

public class Solution {
    public int MaxSubarrayLength(int[] nums, int k) {
        int left = 0, right = 0, max_length = 1;
        int length = nums.Length;
        Dictionary<int, int> frequency = new();
        while (right < length) {
            if (frequency.ContainsKey(nums[right]))
                frequency[nums[right]]++;
            else
                frequency[nums[right]] = 1;
            while (frequency[nums[right]] > k) {
                frequency[nums[left]]--;
                left++;
            }
            max_length = Math.Max(max_length, right - left + 1);
            right++;
        }
        return max_length;
    }
}