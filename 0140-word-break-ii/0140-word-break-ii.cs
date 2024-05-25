using System.Collections.Generic;

public class Solution {
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        List<string> result = new List<string>();
        HashSet<string> wordSet = new HashSet<string>(wordDict);
        Backtrack(s, wordSet, 0, new List<string>(), result);
        return result;
    }

    private void Backtrack(string s, HashSet<string> wordSet, int start, List<string> current, List<string> result) {
        if (start == s.Length) {
            result.Add(string.Join(" ", current));
            return;
        }
        for (int end = start + 1; end <= s.Length; end++) {
            string word = s.Substring(start, end - start);
            if (wordSet.Contains(word)) {
                current.Add(word);
                Backtrack(s, wordSet, end, current, result);
                current.RemoveAt(current.Count - 1); // backtrack
            }
        }
    }
}