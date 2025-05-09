using System.Collections.Generic;
using System;

public class Solution {
    public int MinOperations(int[][] grid, int x) {
        var values = new List<int>();
        foreach (var row in grid) {
            foreach (var val in row)
                values.Add(val);
        }
        values.Sort();
        foreach (var val in values)
            if (Math.Abs(val - values[0]) % x != 0) {
                return -1;
            }
        int median = values[values.Count / 2];
        int operations = 0;
        foreach (var val in values)
            operations += Math.Abs(val - median) / x;
        return operations;
    }
}