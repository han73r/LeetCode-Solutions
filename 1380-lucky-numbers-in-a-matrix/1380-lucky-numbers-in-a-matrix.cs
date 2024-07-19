using System.Collections.Generic;

public class Solution {
    public IList<int> LuckyNumbers(int[][] matrix) {
        IList<int> result = new List<int>();
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        int[] minRow = FindMinInRows(matrix, rows, cols);
        int[] maxCol = FindMaxInCols(matrix, rows, cols);
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (minRow[i] == maxCol[j]) {
                    result.Add(minRow[i]);
                }
            }
        }
        return result;
    }
    private int[] FindMinInRows(int[][] matrix, int rows, int cols) {
        int[] minRow = new int[rows];
        for (int i = 0; i < rows; i++) {
            int minValue = matrix[i][0];
            for (int j = 1; j < cols; j++) {
                if (matrix[i][j] < minValue) {
                    minValue = matrix[i][j];
                }
            }
            minRow[i] = minValue;
        }
        return minRow;
    }
    private int[] FindMaxInCols(int[][] matrix, int rows, int cols) {
        int[] maxCol = new int[cols];
        for (int j = 0; j < cols; j++) {
            int maxValue = matrix[0][j];
            for (int i = 1; i < rows; i++) {
                if (matrix[i][j] > maxValue) {
                    maxValue = matrix[i][j];
                }
            }
            maxCol[j] = maxValue;
        }
        return maxCol;
    }
}