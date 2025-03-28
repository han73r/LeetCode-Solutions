using System.Collections.Generic;
using System;

public class Solution {
    public int[] MaxPoints(int[][] grid, int[] queries) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int n = queries.Length;
        int[] ans = new int[n];
        var indexedQueries = new (int value, int index)[n];

        // Pair each query with its index
        for (int i = 0; i < n; i++) {
            indexedQueries[i] = (queries[i], i);
        }

        // Sort queries based on their values
        Array.Sort(indexedQueries, (a, b) => a.value.CompareTo(b.value));

        // Priority queue to explore the grid
        var pq = new SortedSet<(int value, int row, int col)>();
        pq.Add((grid[0][0], 0, 0)); // (value, row, col)
        bool[,] visited = new bool[rows, cols];
        visited[0, 0] = true;
        int count = 0;

        // Directions for moving in the grid
        var directions = new (int, int)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        // Process each query
        for (int i = 0; i < n; i++) {
            int limit = indexedQueries[i].value; // Current query value
            int index = indexedQueries[i].index; // Original index of the query

            // Explore the grid while the smallest value in the queue is less than the query limit
            while (pq.Count > 0 && pq.Min.value < limit) {
                var (val, r, c) = pq.Min;
                pq.Remove(pq.Min);
                count++; // Count this cell

                // Explore neighbors
                foreach (var (dr, dc) in directions) {
                    int newRow = r + dr;
                    int newCol = c + dc;
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && !visited[newRow, newCol]) {
                        visited[newRow, newCol] = true;
                        pq.Add((grid[newRow][newCol], newRow, newCol));
                    }
                }
            }
            // Store the result for the current query
            ans[index] = count;
        }

        return ans;
    }
}