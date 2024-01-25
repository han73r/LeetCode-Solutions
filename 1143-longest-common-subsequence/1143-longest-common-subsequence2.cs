using System;

public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int len1 = text1.Length, len2 = text2.Length;
        if (len1 < len2) return LongestCommonSubsequence(text2, text1);
        var dp = new int[len1 + 1];
        for (int i = 1; i <= len2; i++)
        {
            int prev = 0;
            for (int j = 1; j <= len1; j++)
            {
                int temp = dp[j];
                dp[j] = text1[j - 1] == text2[i - 1]
                    ? prev + 1
                    : Math.Max(dp[j - 1], dp[j]);
                prev = temp;
            }
        }
        return dp[len1];
    }
}