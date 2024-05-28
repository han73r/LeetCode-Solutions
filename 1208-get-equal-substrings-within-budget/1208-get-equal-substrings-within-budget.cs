using System;

public class Solution {
    public int EqualSubstring(string s, string t, int maxCost) {
        int l = s.Length;
        int left = 0;
        int right = 0;
        int currentCost = 0;
        int maxLength = 0;
        while (right < l) {
            currentCost += Math.Abs(s[right] - t[right]);
            while (currentCost > maxCost) {
                currentCost -= Math.Abs(s[left] - t[left]);
                left++;
            }
            maxLength = Math.Max(maxLength, right - left + 1);
            right++;
        }
        return maxLength;
    }
}