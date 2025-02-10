using System.Collections.Generic;
using System;
using System.Text;

public class Solution {
    public string ClearDigits(string s) {
        int n = s.Length;
        var sb = new StringBuilder();
        foreach (char c in s) {
            if (Char.IsLetter(c)) {
                sb.Append(c);
            } else if (sb.Length > 0) {
                sb.Length--;
            }
        }
        return sb.ToString();
    }
}