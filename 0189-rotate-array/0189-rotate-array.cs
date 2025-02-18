using System;

public class Solution {
    public void Rotate(int[] nums, int k) {
        var minK = k % nums.Length;
        if (minK == 0) return;
        Array.Reverse(nums);
        Array.Reverse(nums, 0, minK);
        Array.Reverse(nums, minK, nums.Length - minK);
    }
}