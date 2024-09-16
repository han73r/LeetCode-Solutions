using System.Collections.Generic;
using System;

public class Solution {
    public int FindMinDifference(IList<string> timePoints) {
        List<int> timePointsInMinutes = new List<int>();
        foreach (var timePoint in timePoints) {
            timePointsInMinutes.Add(TotalMinuites(timePoint));
        }
        return MinDifferenceInList(timePointsInMinutes);
    }
    private int TotalMinuites(string time) {
        string[] parts = time.Split(':');
        return (int.Parse(parts[0]) * 60 + int.Parse(parts[1]));
    }
    private int MinDifferenceInList(List<int> ints) {
        int result = int.MaxValue;
        ints.Sort();
        for (int i = 0; i < ints.Count - 1; i++) {
            result = Math.Min(ints[i + 1] - ints[i], result);
        }
        result = Math.Min(result, 1440 - ints[ints.Count - 1] + ints[0]);
        return result;
    }
}