public class Solution {
    public int ClosedIsland(int[][] grid) {
        int rowCount = grid.Length;
        int colCount = grid[0].Length;
        int closedIslandCount = 0;

        for (int row = 0; row < rowCount; row++) {
            for (int col = 0; col < colCount; col++) {
                if (grid[row][col] != 0) {
                    continue;
                }

                bool isClosed = true;
                ExploreIsland(grid, row, col, rowCount, colCount, ref isClosed);

                if (isClosed) {
                    closedIslandCount++;
                }
            }
        }

        return closedIslandCount;
    }

    private void ExploreIsland(int[][] grid, int row, int col, int rowCount, int colCount, ref bool isClosed) {
        if (row == 0 || row == rowCount - 1 || col == 0 || col == colCount - 1) {
            isClosed = false;
        }

        grid[row][col] = 2;

        int[] rowOffsets = { -1, 0, 1, 0 };
        int[] colOffsets = { 0, 1, 0, -1 };

        for (int i = 0; i < 4; i++) {
            int nextRow = row + rowOffsets[i];
            int nextCol = col + colOffsets[i];

            if (nextRow >= 0 && nextRow < rowCount && nextCol >= 0 && nextCol < colCount && grid[nextRow][nextCol] == 0) {
                ExploreIsland(grid, nextRow, nextCol, rowCount, colCount, ref isClosed);
            }
        }
    }
}
