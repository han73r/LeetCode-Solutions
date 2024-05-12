using System;

public class Solution {
    public int[][] LargestLocal(int[][] grid) {
        int rows = grid.Length - 2;
        int cols = grid[0].Length - 2;
        int[][] newLocal = new int[rows][];
        for (int i = 0; i < rows; i++) {
            newLocal[i] = new int[cols];
            for (int j = 0; j < cols; j++) {
                newLocal[i][j] = GetMaxMatrixValue(grid, i, j);
            }
        }
        return newLocal;
    }
    private int GetMaxMatrixValue(int[][] matrix, int startRow, int startCol) {
        int maxMatrixValue = 0;
        for (int i = startRow; i < startRow + 3; i++) {
            for (int j = startCol; j < startCol + 3; j++) {
                maxMatrixValue = Math.Max(maxMatrixValue, matrix[i][j]);
            }
        }
        return maxMatrixValue;
    }
}