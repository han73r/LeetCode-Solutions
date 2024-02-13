public class Solution {
    public string FirstPalindrome(string[] words) {
        foreach (string word in words) {
            if (IsPalindromic(word)) return word;
        }
        return "";
    }
    private bool IsPalindromic(string s) {
        int l = 0, r = s.Length - 1;
        while (l < r) {
            if (s[l] != s[r]) return false;
            r--;
            l++;
        }
        return true;
    }
}