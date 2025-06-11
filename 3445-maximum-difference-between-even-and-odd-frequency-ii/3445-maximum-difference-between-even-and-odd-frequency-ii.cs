using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    private const int MaxDigit = 4;
    private const int MinStatusValue = int.MaxValue;
    private const int InvalidDifference = int.MinValue;

    public int MaxDifference(string s, int k) {
        int n = s.Length;
        int maxOverallDifference = InvalidDifference;

        for (char charA = '0'; charA <= '0' + MaxDigit; charA++) {
            for (char charB = '0'; charB <= '0' + MaxDigit; charB++) {
                if (charA == charB)
                    continue;
                int[] minDifferenceByStatus = new int[4];
                Array.Fill(minDifferenceByStatus, MinStatusValue);
                int prevCountA = 0;
                int prevCountB = 0;
                int left = -1;
                int currentCountA = 0;
                int currentCountB = 0;
                for (int right = 0; right < n; right++) {
                    if (s[right] == charA)
                        currentCountA++;
                    if (s[right] == charB)
                        currentCountB++;
                    while (right - left >= k && (currentCountB - prevCountB) >= 2) {
                        int leftPartStatus = GetParityStatus(prevCountA, prevCountB);
                        minDifferenceByStatus[leftPartStatus] =
                            Math.Min(minDifferenceByStatus[leftPartStatus], prevCountA - prevCountB);
                        left++;
                        if (s[left] == charA)
                            prevCountA++;
                        if (s[left] == charB)
                            prevCountB++;
                    }
                    int currentWindowStatus = GetParityStatus(currentCountA, currentCountB);
                    int targetStatusForComparison = currentWindowStatus ^ 0b10;
                    if (minDifferenceByStatus[targetStatusForComparison] != MinStatusValue) {
                        maxOverallDifference = Math.Max(
                            maxOverallDifference,
                            (currentCountA - currentCountB) - minDifferenceByStatus[targetStatusForComparison]
                        );
                    }
                }
            }
        }
        return maxOverallDifference;
    }
    private int GetParityStatus(int cntA, int cntB) {
        return ((cntA & 1) << 1) | (cntB & 1);
    }
}