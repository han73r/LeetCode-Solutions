public class Solution {
    public int CountPalindromicSubsequence(string s) {
        HashSet<char> uniqueChars = new HashSet<char>(s);
        int count = uniqueChars
        .AsParallel()
        .Sum(currentChar => {
            int l = s.IndexOf(currentChar);
            int r = s.LastIndexOf(currentChar);
            if (l != -1 && r != -1 && l < r)
                return new HashSet<char>(s.Substring(l + 1, r - l - 1)).Count;
            return 0;
        });
        return count;
    }
}