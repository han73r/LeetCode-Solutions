using System;

public class Solution {
    public long GridGame(int[][] grid) {
        long minResult = long.MaxValue;
        long row1Sum = 0;
        var l = grid[0].Length;
        foreach (var val in grid[0])
            row1Sum += val;
        long row2Sum = 0;
        for (int i = 0; i < l; ++i) {
            row1Sum -= grid[0][i];
            minResult = Math.Min(minResult, Math.Max(row1Sum, row2Sum));
            row2Sum += grid[1][i];
        }
        return minResult;
    }
}