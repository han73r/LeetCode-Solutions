public class Solution {
    private static int rows;
    private static int cols;
    public int NumIslands(char[][] grid) {
        int islandsCount = 0;
        rows = grid.Length;
        cols = grid[0].Length;
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (grid[i][j] == '1') {
                    islandsCount++;
                    DFS(grid, i, j);
                }
            }
        }
        return islandsCount;
    }

    private void DFS(char[][] grid, int row, int col) {
        if (row < 0 || row >= rows || col < 0 || col >= cols || grid[row][col] == '0') {
            return;
        }
        grid[row][col] = '0';
        DFS(grid, row - 1, col);
        DFS(grid, row + 1, col);
        DFS(grid, row, col - 1);
        DFS(grid, row, col + 1);
    }
}