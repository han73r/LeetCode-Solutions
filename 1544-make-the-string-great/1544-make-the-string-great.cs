using System.Text;
using System;

public class Solution {
    public string MakeGood(string s) {
        StringBuilder sb = new StringBuilder(s);
        bool hasBadPair = true;
        while (hasBadPair) {
            hasBadPair = false;
            for (int i = 0; i < sb.Length - 1; i++) {
                if (Math.Abs(sb[i] - sb[i + 1]) == 32) {
                    sb.Remove(i, 2);
                    hasBadPair = true;
                    break;
                }
            }
        }
        return sb.ToString();
    }
}