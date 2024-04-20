using System.Collections.Generic;

public class Solution {
    public int[][] FindFarmland(int[][] land) {
        List<int[]> result = new List<int[]>();
        int m = land.Length;
        int n = land[0].Length;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (land[i][j] == 1) {
                    int[] coordinates = FindGroupBoundaries(land, i, j);
                    result.Add(coordinates);
                }
            }
        }
        return result.ToArray();
    }

    private int[] FindGroupBoundaries(int[][] land, int row, int col) {
        int m = land.Length;
        int n = land[0].Length;

        int r2 = row;
        int c2 = col;

        // Finding bottom-right corner
        while (r2 < m && land[r2][col] == 1) r2++;
        while (c2 < n && land[row][c2] == 1) c2++;

        // Marking visited cells as 0
        for (int i = row; i < r2; i++) {
            for (int j = col; j < c2; j++) {
                land[i][j] = 0;
            }
        }
        return new int[] { row, col, r2 - 1, c2 - 1 };
    }
}