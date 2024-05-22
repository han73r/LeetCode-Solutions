using System.Collections.Generic;

public class Solution {
    public IList<IList<string>> Partition(string s) {
        IList<IList<string>> result = new List<IList<string>>();
        List<string> currentPartition = new List<string>();
        Backtrack(s, 0, currentPartition, result);
        return result;
    }

    private void Backtrack(string s, int index, List<string> currentPartition, IList<IList<string>> result) {
        if (index >= s.Length) {
            result.Add(new List<string>(currentPartition));
            return;
        }
        for (int i = index; i < s.Length; i++) {
            if (IsPalindrome(s, index, i)) {
                currentPartition.Add(s.Substring(index, i - index + 1));
                Backtrack(s, i + 1, currentPartition, result);
                currentPartition.RemoveAt(currentPartition.Count - 1);
            }
        }
    }

    private bool IsPalindrome(string s, int start, int end) {
        while (start < end) {
            if (s[start] != s[end]) {
                return false;
            }
            start++;
            end--;
        }
        return true;
    }
}