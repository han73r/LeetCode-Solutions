using System.Collections.Generic;

public class Solution {
    public int MaximumLength(string s) {
        var dict = new Dictionary<char, int>();
        foreach (char c in s) {
            if (dict.ContainsKey(c)) {
                dict(c)++;
            } else {
                dict.Add(c, 1);
            }
        }
        var sortedByValue = dict.OrderBy(pair => pair.Value);
    }
}