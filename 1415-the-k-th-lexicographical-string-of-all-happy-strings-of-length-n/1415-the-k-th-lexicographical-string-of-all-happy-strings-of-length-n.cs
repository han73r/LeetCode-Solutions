using System.Collections.Generic;

public class Solution {
    private static Dictionary<int, List<string>> happyStringsCache = new Dictionary<int, List<string>>();
    private static char[] happyChars = new char[] { 'a', 'b', 'c' };
    public string GetHappyString(int n, int k) {
        if (!happyStringsCache.ContainsKey(n)) {
            List<string> result = new List<string>();
            GenerateHappyStrings("", n, result);
            happyStringsCache[n] = result;
        }
        List<string> happyStrings = happyStringsCache[n];
        return k <= happyStrings.Count ? happyStrings[k - 1] : "";
    }
    private static void GenerateHappyStrings(string current, int n, List<string> result) {
        if (current.Length == n) {
            result.Add(current);
            return;
        }
        foreach (char ch in happyChars) {
            if (current.Length == 0 || current[current.Length - 1] != ch) {
                GenerateHappyStrings(current + ch, n, result);
            }
        }
    }
}