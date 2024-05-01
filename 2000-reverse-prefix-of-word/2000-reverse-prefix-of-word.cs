using System;

public class Solution {
    public string ReversePrefix(string word, char ch) {
        int index = word.IndexOf(ch);
        if (index != -1) {
            char[] chars = word.ToCharArray();
            Array.Reverse(chars, 0, index + 1);
            return new string(chars);
        }
        return word;
    }
}