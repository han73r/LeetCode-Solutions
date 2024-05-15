using System.Collections.Generic;
using System;

public class Solution {
    // Directions for moving to neighboring cells: right, left, down, up
    int[][] dir = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };

    public int MaximumSafenessFactor(IList<IList<int>> grid) {
        int n = grid.Count;
        int[,] mat = InitializeMatrix(grid, n);
        Queue<int[]> multiSourceQueue = new Queue<int[]>();
        AddThievesToQueue(grid, mat, multiSourceQueue, n);
        CalculateSafenessFactor(mat, multiSourceQueue, n);
        return BinarySearchMaxSafeness(mat, n);
    }
    private int[,] InitializeMatrix(IList<IList<int>> grid, int n) {
        int[,] mat = new int[n, n];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    mat[i, j] = 0;
                } else {
                    mat[i, j] = -1;
                }
            }
        }
        return mat;
    }
    private void AddThievesToQueue(IList<IList<int>> grid, int[,] mat, Queue<int[]> multiSourceQueue, int n) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    multiSourceQueue.Enqueue(new int[] { i, j });
                }
            }
        }
    }
    private void CalculateSafenessFactor(int[,] mat, Queue<int[]> multiSourceQueue, int n) {
        while (multiSourceQueue.Count > 0) {
            int size = multiSourceQueue.Count;
            while (size-- > 0) {
                int[] curr = multiSourceQueue.Dequeue();
                foreach (var d in dir) {
                    int di = curr[0] + d[0];
                    int dj = curr[1] + d[1];
                    int val = mat[curr[0], curr[1]];
                    if (IsValidCell(mat, di, dj) && mat[di, dj] == -1) {
                        mat[di, dj] = val + 1;
                        multiSourceQueue.Enqueue(new int[] { di, dj });
                    }
                }
            }
        }
    }
    private bool IsValidCell(int[,] mat, int i, int j) {
        int n = mat.GetLength(0);
        return i >= 0 && j >= 0 && i < n && j < n;
    }
    private int BinarySearchMaxSafeness(int[,] mat, int n) {
        int start = 0;
        int end = 0;
        int res = -1;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                end = Math.Max(end, mat[i, j]);
            }
        }
        while (start <= end) {
            int mid = start + (end - start) / 2;
            if (IsValidSafeness(mat, mid)) {
                res = mid;
                start = mid + 1;
            } else {
                end = mid - 1;
            }
        }
        return res;
    }
    private bool IsValidSafeness(int[,] grid, int minSafeness) {
        int n = grid.GetLength(0);
        if (grid[0, 0] < minSafeness || grid[n - 1, n - 1] < minSafeness) {
            return false;
        }
        Queue<int[]> traversalQueue = new Queue<int[]>();
        traversalQueue.Enqueue(new int[] { 0, 0 });
        bool[,] visited = new bool[n, n];
        visited[0, 0] = true;
        while (traversalQueue.Count > 0) {
            int[] curr = traversalQueue.Dequeue();
            if (curr[0] == n - 1 && curr[1] == n - 1) {
                return true;
            }
            foreach (var d in dir) {
                int di = curr[0] + d[0];
                int dj = curr[1] + d[1];
                if (IsValidCell(grid, di, dj) && !visited[di, dj] && grid[di, dj] >= minSafeness) {
                    visited[di, dj] = true;
                    traversalQueue.Enqueue(new int[] { di, dj });
                }
            }
        }
        return false;
    }
}