public class Solution {
    public int RegionsBySlashes(string[] grid) {
        int n = grid.Length;
        int size = n * 3;
        int[,] expandedGrid = new int[size, size];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == '/') {
                    expandedGrid[i * 3, j * 3 + 2] = 1;
                    expandedGrid[i * 3 + 1, j * 3 + 1] = 1;
                    expandedGrid[i * 3 + 2, j * 3] = 1;
                }
                if (grid[i][j] == '\\') {
                    expandedGrid[i * 3, j * 3] = 1;
                    expandedGrid[i * 3 + 1, j * 3 + 1] = 1;
                    expandedGrid[i * 3 + 2, j * 3 + 2] = 1;
                }
            }
        }
        int regions = 0;
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                if (expandedGrid[i, j] == 0) {
                    DFS(expandedGrid, i, j);
                    regions++;
                }
            }
        }
        return regions;
    }
    private void DFS(int[,] grid, int x, int y) {
        if (x < 0 || y < 0 || x >= grid.GetLength(0) || y >= grid.GetLength(1) || grid[x, y] != 0) return;
        grid[x, y] = 1;
        DFS(grid, x - 1, y);
        DFS(grid, x + 1, y);
        DFS(grid, x, y - 1);
        DFS(grid, x, y + 1);
    }
}