using System.Collections.Generic;
using System;

public class Solution {
    public int LongestSquareStreak(int[] nums) {
        var numSet = new HashSet<int>(nums);
        var sortedNums = numSet.OrderBy(x => x).ToList();
        int maxLength = 0;
        foreach (int num in sortedNums) {
            int length = 0;
            long current = num;
            while (current <= int.MaxValue && numSet.Contains((int)current)) {
                length++;
                current = current * current;
            }
            if (length > 1) {
                maxLength = Math.Max(maxLength, length);
            }
        }
        return maxLength > 1 ? maxLength : -1;
    }
}