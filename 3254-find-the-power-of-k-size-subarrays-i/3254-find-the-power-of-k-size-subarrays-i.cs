using System.Collections.Generic;

public class Solution {
    public int[] ResultsArray(int[] nums, int k) {
        if (k == 1) {
            return nums;
        }
        int n = nums.Length;
        List<int> result = new List<int>();
        int left = 0;
        int right = 1;
        while (right < n) {
            bool isNotConsecutive = nums[right] - nums[right - 1] != 1;
            if (isNotConsecutive) {
                while (left < right && left + k - 1 < n) {
                    result.Add(-1);
                    left++;
                }
                left = right;
            } else if (right - left == k - 1) {
                result.Add(nums[right]);
                left++;
            }
            right++;
        }
        return result.ToArray();
    }
}