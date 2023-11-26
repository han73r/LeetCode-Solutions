public class Solution
{
    public int LargestSubmatrix(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int[][] heights = new int[m][];

        // Calculate the heights of consecutive 1s in each column
        for (int i = 0; i < m; i++)
        {
            heights[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == 1)
                {
                    heights[i][j] = i > 0 ? heights[i - 1][j] + 1 : 1;
                }
            }
        }
        int maxArea = 0;
        // Sort each row's heights and calculate the area of the largest submatrix
        for (int i = 0; i < m; i++)
        {
            Array.Sort(heights[i]);

            for (int j = n - 1; j >= 0; j--)
            {
                int height = heights[i][j];
                int width = n - j;
                maxArea = Math.Max(maxArea, height * width);
            }
        }
        return maxArea;
    }
}