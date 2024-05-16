using System;
using System.Collections.Generic;

public class Solution {
    public int GetMaximumGold(int[][] grid) {
        int maxGold = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (grid[i][j] != 0) {
                    maxGold = Math.Max(maxGold, DFS(grid, i, j));
                }
            }
        }
        return maxGold;
    }

    private int DFS(int[][] grid, int row, int col) {
        if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length || grid[row][col] == 0) {
            return 0;
        }
        int gold = grid[row][col];
        grid[row][col] = 0;
        int maxGold = gold + Math.Max(
            Math.Max(DFS(grid, row - 1, col), DFS(grid, row + 1, col)),
            Math.Max(DFS(grid, row, col - 1), DFS(grid, row, col + 1))
        );
        grid[row][col] = gold;
        return maxGold;
    }
}