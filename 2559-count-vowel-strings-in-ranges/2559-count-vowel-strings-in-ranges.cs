using System.Collections.Generic;

public class Solution {
    public int[] VowelStrings(string[] words, int[][] queries) {
        int n = words.Length, l = queries.Length;
        int[] Prefix = new int[n + 1];
        HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        for (int i = 0; i < n; i++) {
            Prefix[i + 1] = Prefix[i];
            if (vowels.Contains(words[i][0]) && vowels.Contains(words[i][words[i].Length - 1]))
                Prefix[i + 1]++;
        }
        int[] result = new int[queries.Length];
        for (int i = 0; i < l; i++)
            result[i] = Prefix[queries[i][1] + 1] - Prefix[queries[i][0]];
        return result;
    }
}