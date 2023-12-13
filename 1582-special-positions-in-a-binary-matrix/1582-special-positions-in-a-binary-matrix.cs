public class Solution 
{
    public int NumSpecial(int[][] mat) 
    {
        int count = 0;
        int rows = mat.Length;
        int cols = mat[0].Length;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (mat[i][j] == 1)
                {
                    int rowCount = CountInRow(mat, i);
                    int colCount = CountInColumn(mat, j);

                    if (rowCount == 1 && colCount == 1)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }

    private int CountInRow(int[][] arr, int rowIndex)
    {
        return Array.FindAll(arr[rowIndex], x => x == 1).Length;
    }

    private int CountInColumn(int[][] arr, int colIndex)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i][colIndex] == 1)
            {
                count++;
            }
        }
        return count;
    }
}