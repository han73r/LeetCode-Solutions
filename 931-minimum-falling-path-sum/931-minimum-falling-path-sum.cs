using System.Linq;
using System;

public class Solution
{
    public int MinFallingPathSum(int[][] matrix)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0)
            return 0;

        for (int i = 1; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                int minPrevRow = int.MaxValue;

                if (j > 0)
                    minPrevRow = Math.Min(minPrevRow, matrix[i - 1][j - 1]);

                minPrevRow = Math.Min(minPrevRow, matrix[i - 1][j]);

                if (j < matrix[i].Length - 1)
                    minPrevRow = Math.Min(minPrevRow, matrix[i - 1][j + 1]);

                matrix[i][j] += minPrevRow;
            }
        }

        return matrix[matrix.Length - 1].Min();
    }
}