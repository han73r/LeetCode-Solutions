using System.Linq;
using System;

public class Solution {
    public string ReverseWords(string s) {
        string[] words = s.Split(' ');
        int length = words.Length;
        for (int i = 0; i < length; i++) {
            char[] wordArray = words[i].ToCharArray();
            Array.Reverse(wordArray);
            words[i] = new string(wordArray);
        }
        return string.Join(' ', words);
    }
}