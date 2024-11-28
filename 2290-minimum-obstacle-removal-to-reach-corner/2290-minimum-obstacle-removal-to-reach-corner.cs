using System.Collections.Generic;

public class Solution {
    public int MinimumObstacles(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] nb = new int[][] { new int[] { -1, 0 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { 0, 1 } };
        var pq = new LinkedList<(int, int)>();
        pq.AddFirst((0, 0));
        var d = new int[m, n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                d[i, j] = int.MaxValue;
            }
        }
        d[0, 0] = 0;
        while (pq.Count > 0) {
            var pop = pq.First.Value;
            pq.RemoveFirst();
            for (int i = 0; i < nb.Length; i++) {
                int x = pop.Item1 + nb[i][0];
                int y = pop.Item2 + nb[i][1];
                if (x >= 0 && y >= 0 && x < m && y < n) {
                    int p = d[pop.Item1, pop.Item2] + grid[x][y];
                    if (p < d[x, y]) {
                        d[x, y] = p;
                        if (grid[x][y] == 0)
                            pq.AddFirst((x, y));
                        else
                            pq.AddLast((x, y));
                    }
                }
            }
        }
        return d[m - 1, n - 1];
    }
}