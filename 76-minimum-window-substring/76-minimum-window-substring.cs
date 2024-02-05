using System.Collections.Generic;

public class Solution {
    public string MinWindow(string s, string t) {
        Dictionary<char, int> charCountT = new Dictionary<char, int>();
        foreach (char c in t) {
            if (charCountT.ContainsKey(c)) {
                charCountT[c]++;
            } else {
                charCountT[c] = 1;
            }
        }

        int left = 0, right = 0;
        int minLength = int.MaxValue;
        int minLeft = 0;
        int requiredChars = t.Length;

        while (right < s.Length) {
            if (charCountT.ContainsKey(s[right])) {
                charCountT[s[right]]--;
                if (charCountT[s[right]] >= 0) {
                    requiredChars--;
                }
            }

            while (requiredChars == 0) {
                if (right - left < minLength) {
                    minLength = right - left;
                    minLeft = left;
                }

                if (charCountT.ContainsKey(s[left])) {
                    charCountT[s[left]]++;
                    if (charCountT[s[left]] > 0) {
                        requiredChars++;
                    }
                }
                left++;
            }
            right++;
        }
        return minLength == int.MaxValue ? "" : s.Substring(minLeft, minLength + 1);
    }
}