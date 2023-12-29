using System;

public class Solution
{
    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        int n = jobDifficulty.Length;
        if (n < d) return -1;

        int[] dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue / 2);
        dp[n] = 0;

        for (int day = 1; day <= d; day++)
        {
            for (int i = 0; i <= n - day; i++)
            {
                int maxDifficulty = 0;
                dp[i] = int.MaxValue / 2;

                for (int j = i; j <= n - day; j++)
                {
                    maxDifficulty = Math.Max(maxDifficulty, jobDifficulty[j]);
                    dp[i] = Math.Min(dp[i], maxDifficulty + dp[j + 1]);
                }
            }
        }
        return dp[0];
    }
}