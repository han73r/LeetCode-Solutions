using System.Collections.Generic;

public class Solution {
    public int LongestPalindrome(string s) {
        var dict = Convert(s);
        return CountEvenValues(dict);
    }
    private Dictionary<char, int> Convert(string s) {
        Dictionary<char, int> dict = new();
        for (int i = 0; i < s.Length; i++) {
            if (dict.ContainsKey(s[i])) {
                dict[s[i]]++;
            } else {
                dict.Add(s[i], 1);
            }
        }
        return dict;
    }
    private int CountEvenValues(Dictionary<char, int> dict) {
        int result = 0;
        bool oddAdded = false;
        foreach (var kvp in dict) {
            if (IsEven(kvp.Value)) {
                result += kvp.Value;
            } else {
                if (!oddAdded) {
                    result++;
                    oddAdded = true;
                }
                result += (kvp.Value - 1);
            }
        }
        return result;
    }

    private bool IsEven(int number) {
        if (number % 2 == 0) {
            return true;
        }
        return false;
    }
}