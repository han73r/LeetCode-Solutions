public class Solution {
    public int CountSubIslands(int[][] grid1, int[][] grid2) {
        int m = grid2.Length;
        int n = grid2[0].Length;
        int subIslandsCount = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid2[i][j] == 1) {
                    if (IsSubIsland(grid1, grid2, i, j)) {
                        subIslandsCount++;
                    }
                }
            }
        }
        return subIslandsCount;
    }
    private bool IsSubIsland(int[][] grid1, int[][] grid2, int i, int j) {
        if (i < 0 || j < 0 || i >= grid2.Length || j >= grid2[0].Length || grid2[i][j] == 0) {
            return true;
        }
        bool isSub = true;
        if (grid1[i][j] == 0) {
            isSub = false;
        }
        grid2[i][j] = 0;
        isSub &= IsSubIsland(grid1, grid2, i - 1, j);
        isSub &= IsSubIsland(grid1, grid2, i + 1, j);
        isSub &= IsSubIsland(grid1, grid2, i, j - 1);
        isSub &= IsSubIsland(grid1, grid2, i, j + 1);
        return isSub;
    }
}