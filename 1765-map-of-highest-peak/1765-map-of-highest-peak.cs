using System.Collections.Generic;

public class Solution {
    public int[][] HighestPeak(int[][] isWater) {
        int m = isWater.Length, n = isWater[0].Length;
        int[][] height = new int[m][];
        for (int i = 0; i < m; i++) height[i] = new int[n];
        var queue = new Queue<(int, int)>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                height[i][j] = isWater[i][j] == 1 ? 0 : -1;
                if (isWater[i][j] == 1) queue.Enqueue((i, j));
            }
        }
        int[] dirs = { -1, 0, 1, 0, 0, -1, 0, 1 };
        while (queue.Count > 0) {
            var (x, y) = queue.Dequeue();
            for (int i = 0; i < 4; i++) {
                int newX = x + dirs[i * 2], newY = y + dirs[i * 2 + 1];
                if (newX >= 0 && newX < m && newY >= 0 && newY < n && height[newX][newY] == -1) {
                    height[newX][newY] = height[x][y] + 1;
                    queue.Enqueue((newX, newY));
                }
            }
        }
        return height;
    }
}