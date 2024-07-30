using System;

public class Solution {
    public int MinimumDeletions(string s) {
        int n = s.Length;
        int[] rightACount = new int[n + 1];
        int totalACount = 0;
        for (int i = n - 1; i >= 0; i--) {
            if (s[i] == 'a') {
                totalACount++;
            }
            rightACount[i] = totalACount;
        }
        int minDeletions = rightACount[0];
        int leftBCount = 0;
        for (int i = 0; i < n; i++) {
            if (s[i] == 'b') {
                leftBCount++;
            } else {
                minDeletions = Math.Min(minDeletions, leftBCount + rightACount[i + 1]);
            }
        }
        return minDeletions;
    }
}