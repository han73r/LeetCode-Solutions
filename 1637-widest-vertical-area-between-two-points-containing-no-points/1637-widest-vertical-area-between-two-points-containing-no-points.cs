using System.Collections.Generic;
using System;

public class Solution
{
    public int MaxWidthOfVerticalArea(int[][] points)
    {
        List<int> xCoordinates = new List<int>();
        foreach (var point in points)
        {
            xCoordinates.Add(point[0]);
        }
        xCoordinates.Sort();

        int maxWidth = 0;

        for (int i = 1; i < xCoordinates.Count; i++)
        {
            maxWidth = Math.Max(maxWidth, xCoordinates[i] - xCoordinates[i - 1]);
        }
        return maxWidth;
    }
}