using System.Collections.Generic;
using System;

public class Solution {
    public int MaxUniqueSplit(string s) {
        return Backtrack(s, 0, new HashSet<string>());
    }
    private int Backtrack(string s, int start, HashSet<string> seen) {
        if (start == s.Length) return seen.Count;
        int maxCount = 0;
        for (int end = start + 1; end <= s.Length; end++) {
            string substring = s.Substring(start, end - start);
            if (!seen.Contains(substring)) {
                seen.Add(substring);
                maxCount = Math.Max(maxCount, Backtrack(s, end, seen));
                seen.Remove(substring);
            }
        }
        return maxCount;
    }
}