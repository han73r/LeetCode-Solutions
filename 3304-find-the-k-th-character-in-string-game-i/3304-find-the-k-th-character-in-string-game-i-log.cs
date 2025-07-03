using System.Collections.Generic;
using System;

public class Solution {
    private static Dictionary<int, int> memo = new Dictionary<int, int>();
    public char KthCharacter(int position) {
        int shiftCount = GetShiftCount(position);
        return (char)('a' + shiftCount);
    }
    private int GetShiftCount(int position) {
        if (position == 1) return 0;
        if (memo.ContainsKey(position)) return memo[position];
        int highestPower = (int)Math.Log(position, 2);
        if ((1 << highestPower) == position)
            highestPower--;
        int result = 1 + GetShiftCount(position - (1 << highestPower));
        memo[position] = result;
        return result;
    }
}