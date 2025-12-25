public class Solution {
    public int DeleteGreatestValue(int[][] grid) {
        foreach (var g in grid)
            Array.Sort(g);
        int m = grid[0].Length;
        int n = grid.Length;
        int sum = 0;
        int colMax = 0;
        for (int j = 0; j < m; j++) {
            for (int i = 0; i < n; i++)
                colMax = Math.Max(colMax, grid[i][j]);
            sum += colMax;
        }
        return sum;
    }
}
