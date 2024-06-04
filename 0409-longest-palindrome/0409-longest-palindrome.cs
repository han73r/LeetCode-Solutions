using System.Collections.Generic;

public class Solution {
    public int LongestPalindrome(string s) {
        int length = s.Length;
        if (length == 1) {
            return 1;
        }
        HashSet<int> hashSet = new();
        int result = 0;
        for (int i = 0; i < length; i++) {
            if (hashSet.Contains(s[i])) {
                hashSet.Remove(s[i]);
                result += 2;
            } else {
                hashSet.Add(s[i]);
            }
        }
        if (hashSet.Count > 0) {
            return result + 1;
        } else {
            return result;
        }
    }
}