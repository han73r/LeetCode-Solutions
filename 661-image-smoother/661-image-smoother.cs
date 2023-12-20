using System;

public class Solution
{
    public int[][] ImageSmoother(int[][] img)
    {
        int rows = img.Length;
        int cols = img[0].Length;
        int[][] result = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            result[i] = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                result[i][j] = SmoothPixel(img, i, j, rows, cols);
            }
        }
        return result;
    }

    private int SmoothPixel(int[][] img, int row, int col, int rows, int cols)
    {
        int sum = 0;
        int count = 0;

        for (int i = Math.Max(0, row - 1); i <= Math.Min(rows - 1, row + 1); i++)
        {
            for (int j = Math.Max(0, col - 1); j <= Math.Min(cols - 1, col + 1); j++)
            {
                sum += img[i][j];
                count++;
            }
        }

        return sum / count;
    }
}