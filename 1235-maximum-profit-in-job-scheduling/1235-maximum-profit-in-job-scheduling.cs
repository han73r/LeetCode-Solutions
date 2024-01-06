using System;

public class Solution
{
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        int n = startTime.Length;

        int[][] jobs = new int[n][];
        for (int i = 0; i < n; i++)
            jobs[i] = new int[] { startTime[i], endTime[i], profit[i] };

        Array.Sort(jobs, (a, b) => a[1].CompareTo(b[1]));

        int[] dp = new int[n];
        dp[0] = jobs[0][2];

        for (int i = 1; i < n; i++)
        {
            int currentProfit = jobs[i][2];
            int lastCompatibleJob = FindLastCompatibleJob(jobs, i);
            dp[i] = Math.Max(currentProfit + (lastCompatibleJob == -1 ? 0 : dp[lastCompatibleJob]), dp[i - 1]);
        }
        return dp[n - 1];
    }

    private int FindLastCompatibleJob(int[][] jobs, int currentJob)
    {
        for (int i = currentJob - 1; i >= 0; i--)
            if (jobs[i][1] <= jobs[currentJob][0])
                return i;
        return -1;
    }
}