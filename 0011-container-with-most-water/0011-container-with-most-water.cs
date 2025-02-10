using System;

public class Solution {
    public int MaxArea(int[] height) {
        int left = 0, right = height.Length - 1;
        int result = 0;
        while (left < right) {
            result = Math.Max(result, (Math.Min(height[left], height[right]) * (right - left)));
            if (height[left] > height[right])
                right--;
            else
                left++;
        }
        return result;
    }
}