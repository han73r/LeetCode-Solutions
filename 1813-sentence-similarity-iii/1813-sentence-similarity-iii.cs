using System;

public class Solution {
    public bool AreSentencesSimilar(string sentence1, string sentence2) {
        string[] words1 = sentence1.Split(' ');
        string[] words2 = sentence2.Split(' ');
        int i = 0, j = 0;
        while (i < words1.Length && i < words2.Length && words1[i] == words2[i]) {
            i++;
        }
        while (j < words1.Length - i && j < words2.Length - i && words1[words1.Length - 1 - j] == words2[words2.Length - 1 - j]) {
            j++;
        }
        return i + j >= Math.Min(words1.Length, words2.Length);
    }
}