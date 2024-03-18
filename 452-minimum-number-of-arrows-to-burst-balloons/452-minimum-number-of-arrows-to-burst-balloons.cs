using System;

public class Solution {
    public int FindMinArrowShots(int[][] points) {
        if (points.Length == 0) return 0;
        Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));
        int arrows = 1;
        int prevEnd = points[0][1];
        foreach (var balloon in points) {
            int start = balloon[0];
            int end = balloon[1];
            if (start > prevEnd) {
                arrows++;
                prevEnd = end;
            }
        }
        return arrows;
    }
}