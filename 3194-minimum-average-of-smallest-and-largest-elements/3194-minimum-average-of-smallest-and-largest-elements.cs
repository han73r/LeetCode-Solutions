using System;

public class Solution {
    public double MinimumAverage(int[] nums) {
        Array.Sort(nums);
        int l = nums.Length;
        int left = 0, right = l - 1;
        double minAverage = double.MaxValue;
        while (left < right) {
            double avg = ((nums[left] + nums[right]) / 2.0);
            minAverage = Math.Min(minAverage, avg);
            left++;
            right--;
        }
        return minAverage;
    }
}