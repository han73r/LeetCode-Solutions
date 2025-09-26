using System;

public class Solution {
    public int TriangleNumber(int[] nums) {
        var n = nums.Length;
        if (n < 3) return 0;

        Array.Sort(nums);
        var result = 0;

        for (int k = n - 1; k >= 2; k--) {
            int i = 0, j = k - 1;
            while (i < j) {
                if (nums[i] + nums[j] > nums[k]) {
                    result += (j - i);
                    j--;
                } else {
                    i++;
                }
            }
        }
        return result;
    }
}