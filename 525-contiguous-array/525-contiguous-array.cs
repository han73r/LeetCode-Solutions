using System.Collections.Generic;
using System;

public class Solution {
    public int FindMaxLength(int[] nums) {
        if (nums.Length == 1) return 0;
        int zeroCount = 0;
        int oneCount = 0;
        int maxLen = 0;
        Dictionary<int, int> countToIndex = new Dictionary<int, int>();
        countToIndex[0] = -1;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == 0) {
                zeroCount++;
            } else if (nums[i] == 1) {
                oneCount++;
            }
            int countDiff = zeroCount - oneCount;
            if (countToIndex.ContainsKey(countDiff)) {
                maxLen = Math.Max(maxLen, i - countToIndex[countDiff]);
            } else {
                countToIndex[countDiff] = i;
            }
        }
        return maxLen;
    }
}