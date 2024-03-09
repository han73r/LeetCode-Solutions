using System.Collections.Generic;
using System;

public class Solution {
    public int GetCommon(int[] nums1, int[] nums2) {
        HashSet<int> set = new HashSet<int>();
        foreach (int num in nums1) {
            set.Add(num);
        }
        int minCommon = Int32.MaxValue;
        foreach (int num in nums2) {
            if (set.Contains(num)) {
                minCommon = Math.Min(minCommon, num);
            }
        }
        if (minCommon == Int32.MaxValue) {
            return -1;
        } else {
            return minCommon;
        }
    }
}