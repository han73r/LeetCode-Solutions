using System.Collections.Generic;
using System;

public class Solution {
    public int MinGroups(int[][] intervals) {
        if (intervals.Length == 1) return 1;
        int currentActive = 0;
        int maxGroups = 0;
        List<(int time, int type)> events = new List<(int, int)>();
        foreach (var interval in intervals) {
            events.Add((interval[0], 1));
            events.Add((interval[1] + 1, -1));
        }
        events.Sort();
        foreach (var (time, type) in events) {
            currentActive += type;
            maxGroups = Math.Max(maxGroups, currentActive);
        }
        return maxGroups;
    }
}