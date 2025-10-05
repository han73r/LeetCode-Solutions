using System.Collections.Generic;

public class Solution {
    private static readonly int[][] directions = new int[][] {
        new int[] {1, 0}, new int[] {-1, 0}, new int[] {0, 1}, new int[] {0, -1}
    };
    private int m, n;
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        var result = new List<IList<int>>();
        if (heights == null || heights.Length == 0 || heights[0].Length == 0)
            return result;

        m = heights.Length;
        n = heights[0].Length;

        bool[,] pacific = new bool[m, n];
        bool[,] atlantic = new bool[m, n];

        for (int i = 0; i < m; i++) {
            DFS(heights, pacific, i, 0, int.MinValue);
            DFS(heights, atlantic, i, n - 1, int.MinValue);
        }
        for (int j = 0; j < n; j++) {
            DFS(heights, pacific, 0, j, int.MinValue);
            DFS(heights, atlantic, m - 1, j, int.MinValue);
        }

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (pacific[i, j] && atlantic[i, j]) {
                    result.Add(new List<int> { i, j });
                }
            }
        }

        return result;
    }
    private void DFS(int[][] heights, bool[,] visited, int row, int col, int prevHeight) {
        if (row < 0 || col < 0 || row >= m || col >= n)
            return;
        if (visited[row, col])
            return;
        if (heights[row][col] < prevHeight)
            return;

        visited[row, col] = true;

        foreach (var dir in directions) {
            int newRow = row + dir[0];
            int newCol = col + dir[1];
            DFS(heights, visited, newRow, newCol, heights[row][col]);
        }
    }
}