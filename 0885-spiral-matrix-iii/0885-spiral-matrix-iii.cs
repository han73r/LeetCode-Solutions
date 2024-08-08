public class Solution {
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart) {
        int[][] directions = new int[][] {
            new int[] { 0, 1 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { -1, 0 }
        };
        int totalCells = rows * cols;
        int[][] result = new int[totalCells][];
        bool[,] visited = new bool[rows, cols];
        int currentRow = rStart;
        int currentCol = cStart;
        int directionIndex = 0;
        int stepSize = 1;
        for (int index = 0; index < totalCells;) {
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < stepSize; j++) {
                    if (index >= totalCells) break;
                    if (currentRow >= 0 && currentRow < rows && currentCol >= 0 && currentCol < cols && !visited[currentRow, currentCol]) {
                        result[index++] = new int[] { currentRow, currentCol };
                        visited[currentRow, currentCol] = true;
                    }
                    currentRow += directions[directionIndex][0];
                    currentCol += directions[directionIndex][1];
                }
                directionIndex = (directionIndex + 1) % 4;
            }
            stepSize++;
        }
        return result;
    }
}