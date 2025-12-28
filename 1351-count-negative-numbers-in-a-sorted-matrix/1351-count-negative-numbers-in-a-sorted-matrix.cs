public class Solution {
    public int CountNegatives(int[][] grid) {
        int counter = 0;
        for (int col = 0; col < grid[0].Length; col++) {
            for (int row = 0; row < grid.Length; row++) {
                if (grid[row][col] < 0)
                    counter++;             
            }
        }
        return counter;
    }
}
