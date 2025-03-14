using System;

public class Solution {
    public int MaxScore(string s) {
        int totalZeros = 0, zeros = 0, ans = -1, n = s.Length;
        foreach (char c in s) {
            if (c == '0') totalZeros++;
        }
        for (int i = 1; i < n; i++) {
            if (s[i - 1] == '0') {
                zeros++;
                totalZeros--;
            }
            ans = Math.Max(ans, zeros + (n - totalZeros - i));
        }
        return ans;
    }
}