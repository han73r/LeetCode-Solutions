using System.Text;
using System;

public class Solution {
    public string RepeatLimitedString(string s, int repeatLimit) {
        char[] chars = s.ToCharArray();
        Array.Sort(chars, (a, b) => b.CompareTo(a));
        StringBuilder result = new StringBuilder();
        int freq = 1;
        int pointer = 0;
        for (int i = 0; i < chars.Length; ++i) {
            if (result.Length > 0 && result[result.Length - 1] == chars[i]) {
                if (freq < repeatLimit) {
                    result.Append(chars[i]);
                    freq++;
                } else {
                    pointer = Math.Max(pointer, i + 1);
                    while (pointer < chars.Length && chars[pointer] == chars[i]) {
                        pointer++;
                    }

                    if (pointer < chars.Length) {
                        result.Append(chars[pointer]);
                        char temp = chars[i];
                        chars[i] = chars[pointer];
                        chars[pointer] = temp;
                        freq = 1;
                    } else {
                        break;
                    }
                }
            } else {
                result.Append(chars[i]);
                freq = 1;
            }
        }
        return result.ToString();
    }
}