using System.Collections.Generic;
using System.Linq;
public class Solution {
    public int NumMagicSquaresInside(int[][] grid) {
        if (grid.Length < 3 || LengthLessThen(3, grid)) return 0;
        var squares = GetSquares(grid);
        return CountMagicSquares(squares);
    }
    private bool LengthLessThen(int length, int[][] grid) {
        return grid.Any(row => row.Length < length);
    }
    private List<int[][]> GetSquares(int[][] array) {
        List<int[][]> result = new();
        int rows = array.Length;
        int cols = array[0].Length;
        for (int i = 0; i <= rows - 3; i++) {
            for (int j = 0; j <= cols - 3; j++) {
                result.Add(ExtractSquare(array, i, j));
            }
        }
        return result;
    }
    private int[][] ExtractSquare(int[][] array, int startRow, int startCol) {
        int[][] square = new int[3][];
        for (int i = 0; i < 3; i++) {
            square[i] = new int[3];
            for (int j = 0; j < 3; j++) {
                square[i][j] = array[startRow + i][startCol + j];
            }
        }
        return square;
    }
    private int CountMagicSquares(List<int[][]> squares) {
        int result = default;
        foreach (int[][] square in squares) {
            if (IsMagicSquare(square)) result++;
        }
        return result;
    }
    private bool IsMagicSquare(int[][] square) {
        var distinctNumbers = new HashSet<int>();
        foreach (var row in square) {
            foreach (var num in row) {
                if (num < 1 || num > 9 || !distinctNumbers.Add(num)) return false;
            }
        }
        int targetSum = square[0].Sum();
        for (int i = 0; i < 3; i++) {
            if (square[i].Sum() != targetSum) return false;
            if (square[0][i] + square[1][i] + square[2][i] != targetSum) return false;
        }
        if (square[0][0] + square[1][1] + square[2][2] != targetSum) return false;
        if (square[0][2] + square[1][1] + square[2][0] != targetSum) return false;
        return true;
    }
}