using System.Collections.Generic;
using System.Text;

public class Solution {
    public string FrequencySort(string s) {
        Dictionary<char, int> charFrequency = new Dictionary<char, int>();
        foreach (char ch in s) {
            if (!charFrequency.ContainsKey(ch)) {
                charFrequency[ch] = 0;
            }
            charFrequency[ch]++;
        }
        var sortedChars = charFrequency.OrderByDescending(pair => pair.Value);
        StringBuilder sb = new StringBuilder();
        foreach (var pair in sortedChars) {
            for (int i = 0; i < pair.Value; i++) {
                sb.Append(pair.Key);
            }
        }
        return sb.ToString();
    }
}