using System;

public class Solution {
    public int ScoreOfString(string s) {
        int result = 0;
        int l = s.Length - 1;
        for (int i = 0; i < l; i++) {
            result += Math.Abs(s[i] - s[i + 1]);
        }
        return result;
    }
}