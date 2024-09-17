using System.Collections.Generic;

public class Solution {
    public string[] UncommonFromSentences(string s1, string s2) {
        var wordCount = new Dictionary<string, int>();
        foreach (var word in (s1 + " " + s2).Split(' ')) {
            if (wordCount.ContainsKey(word)) {
                wordCount[word]++;
            } else {
                wordCount[word] = 1;
            }
        }
        var result = new List<string>();
        foreach (var pair in wordCount) {
            if (pair.Value == 1) {
                result.Add(pair.Key);
            }
        }
        return result.ToArray();
    }
}