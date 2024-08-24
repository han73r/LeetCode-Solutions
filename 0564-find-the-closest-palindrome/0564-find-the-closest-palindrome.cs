using System.Collections.Generic;
using System.Text;
using System;

public class Solution {
    public string NearestPalindromic(string n) {
        int length = n.Length;
        if (length == 1) {
            return (char)(n[0] - 1) + "";
        }
        var candidates = new List<long>();
        candidates.Add((long)Math.Pow(10, length) + 1);
        candidates.Add((long)Math.Pow(10, length - 1) - 1);
        int middle = (length + 1) / 2;
        long prefix = long.Parse(n.Substring(0, middle));
        for (long i = -1; i <= 1; i++) {
            long newPrefix = prefix + i;
            string palin = CreatePalindrome(newPrefix.ToString(), length % 2 == 0);
            candidates.Add(long.Parse(palin));
        }
        long originalNumber = long.Parse(n);
        long closestPalindrome = -1;
        foreach (long candidate in candidates) {
            if (candidate == originalNumber) continue;
            if (closestPalindrome == -1 ||
                Math.Abs(candidate - originalNumber) < Math.Abs(closestPalindrome - originalNumber) ||
                (Math.Abs(candidate - originalNumber) == Math.Abs(closestPalindrome - originalNumber) && candidate < closestPalindrome)) {
                closestPalindrome = candidate;
            }
        }
        return closestPalindrome.ToString();
    }
    private string CreatePalindrome(string prefix, bool isEvenLength) {
        var sb = new StringBuilder(prefix);
        for (int i = prefix.Length - (isEvenLength ? 1 : 2); i >= 0; i--) {
            sb.Append(prefix[i]);
        }
        return sb.ToString();
    }
}