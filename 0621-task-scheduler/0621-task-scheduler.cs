using System.Linq;
using System;

public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] taskCounts = new int[26];
        foreach (char task in tasks) {
            taskCounts[task - 'A']++;
        }
        int maxCount = taskCounts.Max();
        int maxCountTasks = 0;
        foreach (int count in taskCounts) {
            if (count == maxCount) {
                maxCountTasks++;
            }
        }
        return Math.Max(tasks.Length, (maxCount - 1) * (n + 1) + maxCountTasks);
    }
}