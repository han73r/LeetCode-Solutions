using System.Collections.Generic;
using System;

public class Solution {
    public IList<string> CommonChars(string[] words) {
        List<string> result = new();
        int[] count = new int[0];
        for (int i = 0; i < words.Length; i++) {
            if (i == 0)
                count = this.Count(words[i]);
            else
                Intersect(count, this.Count(words[i]));
        }
        for (int i = 0; i < count.Length; i++)
            while (count[i]-- > 0)
                result.Add(((char)(i + 'a')).ToString());

        return result;
    }
    private int[] Count(string str) {
        int[] count = new int[26];
        for (int i = 0; i < str.Length; i++)
            ++count[str[i] - 'a'];
        return count;
    }
    private void Intersect(int[] count1, int[] count2) {
        for (int i = 0; i < count1.Length; i++)
            count1[i] = Math.Min(count1[i], count2[i]);
    }
}