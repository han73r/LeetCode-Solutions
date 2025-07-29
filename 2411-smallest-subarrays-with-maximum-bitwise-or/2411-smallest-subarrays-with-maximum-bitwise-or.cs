using System;

public class Solution {
    public int[] SmallestSubarrays(int[] nums) {
        int n = nums.Length;
        int[] res = new int[n];
        int[] last = new int[32];


        for (int i = 0; i < 32; i++) last[i] = -1;

        for (int i = n - 1; i >= 0; i--) {
            for (int j = 0; j < 32; j++) {
                if (((nums[i] >> j) & 1) == 1) {
                    last[j] = i;
                }
            }
            int maxlen = 1;

            for (int k = 0; k < 32; k++) {
                if (last[k] != -1) {
                    maxlen = Math.Max(maxlen, last[k] - i + 1);
                }
            }
            res[i] = maxlen;
        }
        return res;

    }
}