using System;

public class Solution {
    public long MaximumTripletValue(int[] nums) {
        long result = 0;
        int n = nums.Length;
        int[] prefix = new int[n];
        int[] suffix = new int[n];
        prefix[0] = nums[0];
        for (int i = 1; i < n; i++)
            prefix[i] = Math.Max(prefix[i - 1], nums[i]);
        suffix[n - 1] = nums[n - 1];
        for (int k = n - 2; k >= 0; k--)
            suffix[k] = Math.Max(suffix[k + 1], nums[k]);
        for (int j = 1; j < n - 1; j++) {
            long tripletValue = (long)(prefix[j - 1] - nums[j]) * suffix[j + 1];
            result = Math.Max(result, tripletValue);
        }
        return result;
    }
}