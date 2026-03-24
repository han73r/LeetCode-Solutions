public class Solution {
    public int[][] ConstructProductMatrix(int[][] grid) {
        const int modulus = 12345;
        int rows = grid.Length;
        int columns = grid[0].Length;
        int totalCells = rows * columns;

        int[] flattenedValues = new int[totalCells];
        for (int row = 0; row < rows; row++) {
            for (int column = 0; column < columns; column++) {
                flattenedValues[row * columns + column] = grid[row][column] % modulus;
            }
        }

        int[] prefixProducts = new int[totalCells];
        prefixProducts[0] = 1;
        for (int index = 1; index < totalCells; index++) {
            prefixProducts[index] = (int)((long)prefixProducts[index - 1] * flattenedValues[index - 1] % modulus);
        }

        int[] suffixProducts = new int[totalCells];
        suffixProducts[totalCells - 1] = 1;
        for (int index = totalCells - 2; index >= 0; index--) {
            suffixProducts[index] = (int)((long)suffixProducts[index + 1] * flattenedValues[index + 1] % modulus);
        }

        int[][] result = new int[rows][];
        for (int row = 0; row < rows; row++) {
            result[row] = new int[columns];
            for (int column = 0; column < columns; column++) {
                int index = row * columns + column;
                result[row][column] = (int)((long)prefixProducts[index] * suffixProducts[index] % modulus);
            }
        }

        return result;
    }
}
