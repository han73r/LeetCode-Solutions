using System.Text;
using System;

public class Solution {
    public bool IsPalindrome(string s) {
        s = CleanAndSetUpperToLower(s);
        int left = 0, right = s.Length - 1;
        while (left < right) {
            if (s[left] != s[right]) return false;
            left++;
            right--;
        }
        return true;
    }
    private string CleanAndSetUpperToLower(string s) {
        StringBuilder result = new StringBuilder();
        foreach (char ch in s)
            if (Char.IsLetterOrDigit(ch))
                result.Append(Char.ToLower(ch));
        return result.ToString();
    }
}