using System.Collections.Generic;
using System;

public class Solution {
    public int FindMaxK(int[] nums) {
        HashSet<int> set = new HashSet<int>(nums);
        int largestK = -1;
        foreach (int num in nums) {
            if (set.Contains(-num)) {
                largestK = Math.Max(largestK, Math.Abs(num));
            }
        }
        return largestK;
    }
}