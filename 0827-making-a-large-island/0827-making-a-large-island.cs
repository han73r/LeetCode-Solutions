using System.Collections.Generic;
using System;

public class Solution {
    private static readonly int[][] directions = {
        new[] {0, 1}, new[] {0, -1}, new[] {1, 0}, new[] {-1, 0}
    };
    public int LargestIsland(int[][] grid) {
        int n = grid.Length;
        int index = 2;
        Dictionary<int, int> islandSize = new();
        bool hasZero = false;
        int maxIsland = 0;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    int size = DFS(grid, i, j, index);
                    islandSize[index] = size;
                    maxIsland = Math.Max(maxIsland, size);
                    index++;
                } else if (grid[i][j] == 0) {
                    hasZero = true;
                }
            }
        }
        if (!hasZero) return maxIsland;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0) {
                    HashSet<int> seenIslands = new();
                    int newSize = 1;
                    foreach (var dir in directions) {
                        int ni = i + dir[0], nj = j + dir[1];
                        if (ni >= 0 && ni < n && nj >= 0 && nj < n && grid[ni][nj] > 1) {
                            if (seenIslands.Add(grid[ni][nj]))
                                newSize += islandSize[grid[ni][nj]];
                        }
                    }
                    maxIsland = Math.Max(maxIsland, newSize);
                }
            }
        }
        return maxIsland;
    }
    private int DFS(int[][] grid, int i, int j, int index) {
        int n = grid.Length;
        Stack<(int, int)> stack = new();
        stack.Push((i, j));
        int size = 0;
        while (stack.Count > 0) {
            (i, j) = stack.Pop();
            if (i < 0 || i >= n || j < 0 || j >= n || grid[i][j] != 1) continue;
            grid[i][j] = index;
            size++;
            foreach (var dir in directions)
                stack.Push((i + dir[0], j + dir[1]));
        }
        return size;
    }
}