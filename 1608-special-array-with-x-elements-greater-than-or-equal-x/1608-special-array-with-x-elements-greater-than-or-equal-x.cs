using System;

public class Solution {
    public int SpecialArray(int[] nums) {
        Array.Sort(nums);
        int l = nums.Length;
        for (int x = 0; x <= l; x++) {
            int counter = 0;
            for (int i = 0; i < l; i++) {
                if (nums[i] >= x) {
                    counter++;
                }
                if (counter > x) {
                    break;
                }
            }
            if (counter == x) {
                return x;
            }
        }
        return -1;
    }
}