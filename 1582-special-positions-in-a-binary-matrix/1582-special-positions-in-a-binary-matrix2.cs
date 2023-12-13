public class Solution
{
    public int NumSpecial(int[][] mat)
    {
        int count = 0;
        int rows = mat.Length;
        int cols = mat[0].Length;

        int[] rowSum = new int[rows];
        int[] colSum = new int[cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                rowSum[i] += mat[i][j];
                colSum[j] += mat[i][j];
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (mat[i][j] == 1 && rowSum[i] == 1 && colSum[j] == 1)
                {
                    count++;
                }
            }
        }

        return count;
    }
}