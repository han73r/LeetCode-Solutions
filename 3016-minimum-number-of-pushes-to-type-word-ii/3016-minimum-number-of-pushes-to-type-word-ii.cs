using System.Collections.Generic;

public class Solution {
    public int MinimumPushes(string word) {
        if (word.Length < 9) return word.Length;
        var charCounter = CountCharactersInString(word);
        var sortedCharCounter = SortDictByValue(charCounter);
        return CountNumpadPushes(sortedCharCounter);

    }
    private Dictionary<char, int> CountCharactersInString(string s) {
        var dict = new Dictionary<char, int>();
        foreach (char c in s) {
            if (dict.ContainsKey(c)) {
                dict[c]++;
            } else {
                dict.Add(c, 1);
            }
        }
        return dict;
    }
    private Dictionary<char, int> SortDictByValue(Dictionary<char, int> dict) {
        return dict.OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
    private int CountNumpadPushes(Dictionary<char, int> sortedDict) {
        int result = default;
        int index = default;
        int multiplier = 1;
        foreach (var kvp in sortedDict) {
            if (index != 0 && index % 8 == 0) {
                multiplier++;
            }
            result += kvp.Value * multiplier;
            index++;
        }
        return result;
    }
}