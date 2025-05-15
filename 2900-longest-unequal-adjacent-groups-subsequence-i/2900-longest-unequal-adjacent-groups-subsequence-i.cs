public class Solution {
    public IList<string> GetLongestSubsequence(string[] words, int[] groups) {
        var n = groups.Length;
        var ans = new List<string>();
        for (int i = 0; i < n; ++i)
            if (i == 0 || groups[i] != groups[i - 1])
                ans.Add(words[i]);
        return ans;
    }
}