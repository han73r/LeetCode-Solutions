using System;

public class Solution {
    public int MatrixScore(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;

        // check rows
        for (int i = 0; i < rows; i++) {
            if (grid[i][0] == 0) {
                grid[i] = ReverseRow(grid[i]);
            }
        }

        // check cols
        for (int j = 0; j < cols; j++) {
            if (ZerosMoreThanOnes(grid, j)) {
                ReverseCol(grid, j);
            }
        }

        // count result
        return CountResult(grid);
    }

    private int[] ReverseRow(int[] row) {
        int[] reversedRow = new int[row.Length];
        for (int i = 0; i < row.Length; i++) {
            reversedRow[i] = row[i] == 0 ? 1 : 0;
        }
        return reversedRow;
    }

    private void ReverseCol(int[][] grid, int col) {
        for (int i = 0; i < grid.Length; i++) {
            grid[i][col] = grid[i][col] == 0 ? 1 : 0;
        }
    }

    private bool ZerosMoreThanOnes(int[][] grid, int col) {
        int zerosCount = 0;
        int onesCount = 0;
        foreach (var row in grid) {
            if (row[col] == 0) {
                zerosCount++;
            } else {
                onesCount++;
            }
        }
        return zerosCount > onesCount;
    }

    private int CountResult(int[][] grid) {
        int result = 0;
        foreach (var row in grid) {
            result += BinaryToDecimal(row);
        }
        return result;
    }

    private int BinaryToDecimal(int[] binaryArray) {
        int decimalNumber = 0;
        int power = binaryArray.Length - 1;
        foreach (int bit in binaryArray) {
            decimalNumber += bit * (int)Math.Pow(2, power);
            power--;
        }
        return decimalNumber;
    }
}