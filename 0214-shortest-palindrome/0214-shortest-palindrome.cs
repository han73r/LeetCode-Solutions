using System.Linq;

public class Solution {
    public string ShortestPalindrome(string s) {
        string rev = new string(s.ToCharArray().Reverse().ToArray());
        string l = s + "#" + rev;
        int[] p = new int[l.Length];
        for (int i = 1; i < l.Length; i++) {
            int j = p[i - 1];
            while (j > 0 && l[i] != l[j]) j = p[j - 1];
            if (l[i] == l[j]) j++;
            p[i] = j;
        }
        return rev.Substring(0, s.Length - p[l.Length - 1]) + s;
    }
}