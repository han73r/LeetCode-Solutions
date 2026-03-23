public class Solution {
    private const int Modulus = 1_000_000_007;

    public int MaxProductPath(int[][] grid) {
        int rows = grid.Length;
        int columns = grid[0].Length;

        Span<long> maxProducts = stackalloc long[columns];
        Span<long> minProducts = stackalloc long[columns];

        maxProducts[0] = grid[0][0];
        minProducts[0] = grid[0][0];

        for (int column = 1; column < columns; column++) {
            maxProducts[column] = maxProducts[column - 1] * grid[0][column];
            minProducts[column] = minProducts[column - 1] * grid[0][column];
        }

        for (int row = 1; row < rows; row++) {
            maxProducts[0] = maxProducts[0] * grid[row][0];
            minProducts[0] = minProducts[0] * grid[row][0];

            for (int column = 1; column < columns; column++) {
                int currentValue = grid[row][column];

                long fromTopMax = currentValue * maxProducts[column];
                long fromTopMin = currentValue * minProducts[column];
                long fromLeftMax = currentValue * maxProducts[column - 1];
                long fromLeftMin = currentValue * minProducts[column - 1];

                maxProducts[column] = Math.Max(
                    Math.Max(fromTopMax, fromTopMin),
                    Math.Max(fromLeftMax, fromLeftMin)
                );

                minProducts[column] = Math.Min(
                    Math.Min(fromTopMax, fromTopMin),
                    Math.Min(fromLeftMax, fromLeftMin)
                );
            }
        }

        long result = maxProducts[columns - 1];
        return result < 0 ? -1 : (int)(result % Modulus);
    }
}
