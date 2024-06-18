using System.Linq;
using System;

public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        int maxProfit = 0;
        int totalProfit = 0;
        int jobIndex = 0;
        var jobs = difficulty
                .Zip(profit, (d, p) => new { Difficulty = d, Profit = p })
                .OrderBy(job => job.Difficulty)
                .ToList();
        Array.Sort(worker);
        foreach (int ability in worker) {
            while (jobIndex < jobs.Count && jobs[jobIndex].Difficulty <= ability) {
                maxProfit = Math.Max(maxProfit, jobs[jobIndex].Profit);
                jobIndex++;
            }
            totalProfit += maxProfit;
        }
        return totalProfit;
    }
}