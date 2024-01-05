using System.Linq;
using System;

public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        int length = nums.Length;
        if (length < 2) return length;

        int[] dp = new int[length];
        Array.Fill(dp, 1);

        for (int i = 1; i < length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }
        return dp.Max();
    }
}