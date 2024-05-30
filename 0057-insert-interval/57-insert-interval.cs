using System.Collections.Generic;
using System;

public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        List<int[]> result = new List<int[]>();
        int newStart = newInterval[0];
        int newEnd = newInterval[1];

        int i = 0;
        while (i < intervals.Length && intervals[i][1] < newStart) {
            result.Add(intervals[i]);
            i++;
        }

        while (i < intervals.Length && intervals[i][0] <= newEnd) {
            newStart = Math.Min(newStart, intervals[i][0]);
            newEnd = Math.Max(newEnd, intervals[i][1]);
            i++;
        }

        result.Add(new int[] { newStart, newEnd });

        while (i < intervals.Length) {
            result.Add(intervals[i]);
            i++;
        }

        return result.ToArray();
    }
}