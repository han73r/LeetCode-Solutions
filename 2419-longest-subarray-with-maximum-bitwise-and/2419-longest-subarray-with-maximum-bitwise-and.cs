using System.Linq;
using System;

public class Solution {
    public int LongestSubarray(int[] nums) {
        int max = nums.Max();
        int maxLen = 0, currentLen = 0;
        foreach (int num in nums) {
            if (num == max) {
                currentLen++;
                maxLen = Math.Max(maxLen, currentLen);
            } else {
                currentLen = 0;
            }
        }
        return maxLen;
    }
}