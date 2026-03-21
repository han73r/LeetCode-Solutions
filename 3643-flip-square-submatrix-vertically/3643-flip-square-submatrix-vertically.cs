public class Solution {
    public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k) {
        var startRow = x;
        var endRow = x + k - 1;
        while (endRow > startRow) {
            for (int i = y; i < (y + k); i++) {
                var temp = grid[endRow][i];
                grid[endRow][i] = grid[startRow][i];
                grid[startRow][i] = temp;
            }
            endRow--;
            startRow++;
        }
        return grid;
    }
}
