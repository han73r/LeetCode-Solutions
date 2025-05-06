using System;

public class Solution {
    private static readonly int[] buffer = new int[1000];
    public int[] BuildArray(int[] nums) {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
            buffer[i] = nums[nums[i]];
        int[] result = new int[n];
        Array.Copy(buffer, result, n);
        return result;
    }
}