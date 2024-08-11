public class Solution {
    public int MinDays(int[][] grid) {
        int rows = grid.Length, cols = grid[0].Length;
        if (CountIslands(grid) != 1) return 0;
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (grid[i][j] == 1) {
                    grid[i][j] = 0;
                    if (CountIslands(grid) != 1) return 1;
                    grid[i][j] = 1;
                }
            }
        }
        return 2;
    }
    private int CountIslands(int[][] grid) {
        int rows = grid.Length, cols = grid[0].Length, count = 0;
        bool[,] visited = new bool[rows, cols];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (grid[i][j] == 1 && !visited[i, j]) {
                    DFS(grid, visited, i, j);
                    count++;
                }
            }
        }
        return count;
    }
    private void DFS(int[][] grid, bool[,] visited, int x, int y) {
        int[] directions = new int[] { 0, 1, 0, -1, 0 };
        visited[x, y] = true;
        for (int d = 0; d < 4; d++) {
            int nx = x + directions[d], ny = y + directions[d + 1];
            if (nx >= 0 && ny >= 0 && nx < grid.Length && ny < grid[0].Length && grid[nx][ny] == 1 && !visited[nx, ny]) {
                DFS(grid, visited, nx, ny);
            }
        }
    }
}
