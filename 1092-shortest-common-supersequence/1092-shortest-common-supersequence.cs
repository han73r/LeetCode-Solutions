using System.Text;
using System;

public class Solution {
    public string ShortestCommonSupersequence(string str1, string str2) {
        int[,] dp = ComputeLcsTable(str1, str2);
        return BuildSupersequence(str1, str2, dp);
    }
    private int[,] ComputeLcsTable(string str1, string str2) {
        int m = str1.Length, n = str2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                if (str1[i - 1] == str2[j - 1])
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }
        return dp;
    }
    private string BuildSupersequence(string str1, string str2, int[,] dp) {
        int i = str1.Length, j = str2.Length;
        var result = new StringBuilder();
        while (i > 0 && j > 0) {
            if (str1[i - 1] == str2[j - 1]) {
                result.Append(str1[i - 1]);
                i--; j--;
            } else if (dp[i - 1, j] > dp[i, j - 1]) {
                result.Append(str1[i - 1]);
                i--;
            } else {
                result.Append(str2[j - 1]);
                j--;
            }
        }
        AppendRemainingCharacters(str1, i, result);
        AppendRemainingCharacters(str2, j, result);
        return ReverseString(result);
    }
    private void AppendRemainingCharacters(string str, int index, StringBuilder result) {
        while (index > 0) {
            result.Append(str[index - 1]);
            index--;
        }
    }
    private string ReverseString(StringBuilder sb) {
        char[] charArray = sb.ToString().ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
